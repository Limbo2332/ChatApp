import { Component, OnInit } from '@angular/core';
import { ResizeEvent } from 'angular-resizable-element';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { finalize } from 'rxjs';
import { AuthService } from 'src/app/core/services/auth.service';
import { ChatHubService } from 'src/app/core/services/chat-hub.service';
import { ChatsService } from 'src/app/core/services/chats.service';
import { EventService } from 'src/app/core/services/event.service';
import { IChatPreview } from 'src/app/shared/models/chats/chat-preview';
import { IChatRead } from 'src/app/shared/models/chats/chat-read';
import { IMessagePreview } from 'src/app/shared/models/messages/message-preview';
import { IPageSettings } from 'src/app/shared/models/page/page-settings';
import { IUser } from 'src/app/shared/models/user/user';

import { minChatsWidth, minConversationsWidth } from '../chat-utils';

@Component({
  selector: 'app-chats',
  templateUrl: './chats.component.html',
  styleUrls: ['../chats.component.sass'],
})
export class ChatsComponent implements OnInit {
  chatStyles: object = {
    'width.px': minChatsWidth * 2,
    'min-width.px': minChatsWidth,
    'max-width.px': window.innerWidth - minConversationsWidth,
  };

  conversationStyles: object = {
    'width.px': window.innerWidth - minChatsWidth * 2,
    'min-width.px': minConversationsWidth,
    'max-width.px': window.innerWidth - minChatsWidth,
  };

  chats: IChatPreview[] = [];

  selectedChatId?: number;

  private cachedChats: IChatPreview[] = [];

  private newChatIdentifier: string = 'newChat';

  private activeChatName = 'activeChat';

  private user: IUser;

  constructor(
    private modalService: NgxSmartModalService,
    private authService: AuthService,
    private chatsService: ChatsService,
    private chatHubService: ChatHubService,
    private eventService: EventService,
    private toastrService: ToastrService,
    private spinner: NgxSpinnerService,
  ) {}

  ngOnInit(): void {
    this.removeActiveChat();

    this.getChats();

    this.registerEventOnNewChatCreated();

    this.registerEventOnMessageCreated();

    this.registerEventOnMessageReceived();

    this.registerEventOnReadMessages();

    this.authService.getUser().subscribe((user: IUser) => {
      this.user = user;
    });
  }

  getChatsByUserName(userName: string) {
    if (userName) {
      const pageSettings: IPageSettings = {
        filter: {
          propertyName: 'LastMessage.Value',
          propertyValue: userName,
        },
      };

      this.chatsService.getChats(pageSettings).subscribe(
        (chats: IChatPreview[]) => {
          this.chats = chats;
        },
        (errors?: string[]) => {
          if (errors) {
            errors.forEach((error) => this.toastrService.error(error));
          } else {
            this.toastrService.error('Server connection error');
          }
        },
      );
    } else {
      this.chats = this.cachedChats;
    }
  }

  selectChat(chatId: number) {
    localStorage.setItem(this.activeChatName, chatId.toString());
    this.selectedChatId = chatId;

    const chatRead: IChatRead = {
      id: chatId,
      userId: this.user.id,
    };

    this.updateSelectChatWhenGotMessages(chatId, chatRead);
  }

  isActiveChat(chatId: number) {
    return localStorage.getItem(this.activeChatName) === chatId.toString();
  }

  onChatResizeEnd(event: ResizeEvent) {
    this.chatStyles = {
      ...this.chatStyles,
      'width.px': event.rectangle.width,
    };

    this.conversationStyles = {
      ...this.conversationStyles,
      'width.px': window.innerWidth - (event.rectangle.width ?? 0),
    };
  }

  onNewMessage(message: IMessagePreview) {
    const updatedChat = this.getChat(message.chatId);

    updatedChat.lastMessage = message;

    if (!message.isMine && updatedChat.id === this.selectedChatId) {
      updatedChat.lastMessage.isRead = true;

      const chatRead: IChatRead = {
        id: updatedChat.id,
        userId: this.user.id,
      };

      this.readMessages(chatRead);
    }

    if (!message.isMine && updatedChat.id !== this.selectedChatId) {
      updatedChat.interlocutorUnreadMessagesCount += 1;
    }

    this.chats = [...new Set([updatedChat, ...this.chats])];
  }

  onNewChatForInterlocutor(chat: IChatPreview) {
    chat.interlocutorUnreadMessagesCount += 1;

    this.chats = [chat, ...this.chats];
  }

  onNewChatForCurrentUser(chat: IChatPreview) {
    chat.lastMessage.isMine = true;

    this.chats = [chat, ...this.chats];
    this.modalService.close(this.newChatIdentifier);
  }

  openNewChatModal() {
    this.modalService.open(this.newChatIdentifier);
  }

  private removeActiveChat() {
    return localStorage.removeItem(this.activeChatName);
  }

  private getChats() {
    this.spinner.show();

    this.chatsService
      .getChats()
      .pipe(
        finalize(() => {
          this.spinner.hide();
        }),
      )
      .subscribe(
        (chats: IChatPreview[]) => {
          this.chats = chats;
          this.cachedChats = chats;
          this.chatHubService.startConnection();
        },
        (errors?: string[]) => {
          if (errors) {
            errors.forEach((error) => this.toastrService.error(error));
          } else {
            this.toastrService.error('Server connection error');
          }
        },
      );
  }

  private registerEventOnNewChatCreated() {
    this.eventService.newChatCreatedEvent$.subscribe(
      (newChat: IChatPreview) => {
        this.onNewChatForInterlocutor(newChat);
      },
    );
  }

  private registerEventOnMessageCreated() {
    this.eventService.newMessageSentEvent$.subscribe(
      (message: IMessagePreview) => {
        this.onNewMessage(message);
      },
    );
  }

  private registerEventOnMessageReceived() {
    this.eventService.newMessageReceived$.subscribe(
      (message: IMessagePreview) => {
        this.onNewMessage(message);
      },
    );
  }

  private registerEventOnReadMessages() {
    this.eventService.readMessages$.subscribe((chat: IChatRead) => {
      this.onReadMessages(chat);
    });
  }

  private getChat(chatId: number) {
    return this.chats.find((chat) => chat.id === chatId)!;
  }

  private readMessages(chatRead: IChatRead) {
    this.chatsService.readMessages(chatRead).subscribe(() => {
      const updatedChat = this.chats.find((chat) => chat.id === chatRead.id)!;

      updatedChat.interlocutorUnreadMessagesCount = 0;
    });
  }

  private onReadMessages(chatRead: IChatRead) {
    const updatedChat = this.chats.find((chat) => chat.id === chatRead.id)!;

    updatedChat.interlocutorUnreadMessagesCount = 0;
    updatedChat.lastMessage.isRead = true;
  }

  private updateSelectChatWhenGotMessages(chatId: number, chatRead: IChatRead) {
    const selectedChat = this.getChat(chatId);

    if (selectedChat.interlocutorUnreadMessagesCount) {
      this.readMessages(chatRead);
    }
  }
}
