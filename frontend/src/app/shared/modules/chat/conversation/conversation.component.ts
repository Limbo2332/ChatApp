import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
} from '@angular/core';
import {
  fadeInLeftOnEnterAnimation,
  fadeInRightOnEnterAnimation,
} from 'angular-animations';
import { ToastrService } from 'ngx-toastr';
import { ChatsService } from 'src/app/core/services/chats.service';
import { EventService } from 'src/app/core/services/event.service';
import { IChatConversation } from 'src/app/shared/models/conversation/chat-conversation';
import { IMessagePreview } from 'src/app/shared/models/messages/message-preview';
import { INewMessage } from 'src/app/shared/models/messages/new-message';
import { IPageSettings } from 'src/app/shared/models/page/page-settings';

import { defaultImagePath, toDatePreview } from '../chat-utils';

@Component({
  selector: 'app-conversation',
  templateUrl: './conversation.component.html',
  styleUrls: ['../chats.component.sass'],
  animations: [
    fadeInLeftOnEnterAnimation({ duration: 250 }),
    fadeInRightOnEnterAnimation({ duration: 250 }),
  ],
})
export class ConversationComponent implements OnInit, OnChanges {
  @Input() chatId?: number;

  conversation?: IChatConversation;

  newMessageValue?: string;

  defaultImagePath = defaultImagePath;

  toDatePreview = toDatePreview;

  private currentPageNumber = 1;

  private pageSize = 30;

  constructor(
    private chatsService: ChatsService,
    private eventService: EventService,
    private toastrService: ToastrService,
  ) {}

  ngOnInit(): void {
    this.registerEventOnNewMessageSent();

    this.registerEventOnMessageRead();
  }

  ngOnChanges({ chatId }: SimpleChanges): void {
    if (chatId.currentValue) {
      this.currentPageNumber = 1;

      const pageSettings: IPageSettings = {
        pagination: {
          pageNumber: this.currentPageNumber,
          pageSize: this.pageSize,
        },
      };

      this.chatsService
        .getConversationChat(chatId.currentValue, pageSettings)
        .subscribe(
          (conversation: IChatConversation) => {
            this.conversation = conversation;
          },
          (errors: string[]) => {
            errors.forEach((error) => this.toastrService.error(error));
          },
        );
    }
  }

  identify(index: number, item: IMessagePreview) {
    return item.sentAt;
  }

  getNewMessages() {
    this.currentPageNumber++;

    const pageSettings: IPageSettings = {
      pagination: {
        pageNumber: this.currentPageNumber,
        pageSize: this.pageSize,
      },
    };

    this.chatsService.getConversationChat(this.chatId!, pageSettings).subscribe(
      (conversation: IChatConversation) => {
        const currentMessages = this.conversation?.messages ?? [];

        this.conversation = conversation;

        this.conversation.messages = [
          ...currentMessages,
          ...this.conversation.messages,
        ];
      },
      (errors: string[]) => {
        errors.forEach((error) => this.toastrService.error(error));
      },
    );
  }

  sendMessage(value: string) {
    const newMessage: INewMessage = {
      value,
      chatId: this.chatId!,
    };

    this.chatsService.addMessage(newMessage).subscribe(
      (message: IMessagePreview) => {
        this.updateMessages(message);
        this.eventService.receiveNewMessage(message);
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

  private registerEventOnNewMessageSent() {
    this.eventService.newMessageSentEvent$.subscribe(
      (message: IMessagePreview) => {
        if (message.chatId === this.chatId) {
          this.updateMessages(message);
        }
      },
    );
  }

  private registerEventOnMessageRead() {
    this.eventService.readMessages$.subscribe(() => {
      this.conversation?.messages.forEach((message) => {
        message.isRead = true;
      });
    });
  }

  private updateMessages(message: IMessagePreview) {
    this.conversation!.messages = [message, ...this.conversation!.messages];
    this.newMessageValue = '';
  }
}
