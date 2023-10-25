import { Component, OnInit } from '@angular/core';
import { ResizeEvent } from 'angular-resizable-element';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { AuthService } from 'src/app/core/services/auth.service';
import { ChatHubService } from 'src/app/core/services/chat-hub.service';
import { ChatsService } from 'src/app/core/services/chats.service';
import { EventService } from 'src/app/core/services/event.service';
import { IChatPreview } from 'src/app/shared/models/chats/chat-preview';
import { IChatRead } from 'src/app/shared/models/chats/chat-read';
import { IMessagePreview } from 'src/app/shared/models/messages/message-preview';
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

  private newChatIdentifier: string = 'newChat';

  private activeChatName = 'activeChat';

  private user: IUser;

  constructor(
    private modalService: NgxSmartModalService,
    private authService: AuthService,
    private chatsService: ChatsService,
    private chatHubService: ChatHubService,
    private eventService: EventService,
  ) {}

  ngOnInit(): void {
    this.removeActiveChat();

    this.getChats();

    this.eventService.newChatCreatedEvent$.subscribe(
      (newChat: IChatPreview) => {
        this.onNewChat(newChat);
      },
    );

    this.eventService.newMessageSentEvent$.subscribe(
      (message: IMessagePreview) => {
        this.onNewMessage(message);
      },
    );

    this.eventService.newMessageReceived$.subscribe(
      (message: IMessagePreview) => {
        this.onNewMessage(message);
      },
    );

    this.eventService.readMessages$.subscribe((chat: IChatRead) => {
      this.onReadMessages(chat);
    });

    this.authService.getUser().subscribe((user: IUser) => {
      this.user = user;
    });
  }

  selectChat(chatId: number) {
    localStorage.setItem(this.activeChatName, chatId.toString());
    this.selectedChatId = chatId;

    const chatRead: IChatRead = {
      id: chatId,
      userId: this.user.id,
    };

    const selectedChat = this.chats.find((chat) => chat.id === chatId)!;

    if (selectedChat.unreadMessagesCount) {
      this.readMessages(chatRead);
    }
  }

  isActiveChat(chatId: number) {
    return localStorage.getItem(this.activeChatName) === chatId.toString();
  }

  removeActiveChat() {
    return localStorage.removeItem(this.activeChatName);
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
    const updatedChat = this.chats.find((chat) => chat.id === message.chatId)!;

    updatedChat.lastMessage = message;

    if (!message.isMine && updatedChat.id === this.selectedChatId) {
      updatedChat.lastMessage.isRead = true;
    }

    if (!message.isMine && updatedChat.id !== this.selectedChatId) {
      updatedChat.unreadMessagesCount += 1;
    }

    if (!message.isMine && updatedChat.id === this.selectedChatId) {
      const chatRead: IChatRead = {
        id: updatedChat.id,
        userId: this.user.id,
      };

      this.readMessages(chatRead);
    }

    this.chats = [...new Set([updatedChat, ...this.chats])];
  }

  onNewChat(chat: IChatPreview) {
    this.chats = [chat, ...this.chats];
    this.modalService.close(this.newChatIdentifier);
  }

  openNewChatModal() {
    this.modalService.open(this.newChatIdentifier);
  }

  private readMessages(chatRead: IChatRead) {
    this.chatsService.readMessages(chatRead).subscribe(() => {
      const updatedChat = this.chats.find((chat) => chat.id === chatRead.id)!;

      updatedChat.unreadMessagesCount = 0;
    });
  }

  private onReadMessages(chatRead: IChatRead) {
    const updatedChat = this.chats.find((chat) => chat.id === chatRead.id)!;

    updatedChat.unreadMessagesCount = 0;
    updatedChat.lastMessage.isRead = true;
  }

  private getChats() {
    this.chatsService.getChats().subscribe((chats: IChatPreview[]) => {
      this.chats = chats;
      this.chatHubService.startConnection();
    });
  }
}
