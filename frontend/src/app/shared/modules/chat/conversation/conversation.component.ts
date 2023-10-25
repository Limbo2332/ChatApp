import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
} from '@angular/core';
import { ChatsService } from 'src/app/core/services/chats.service';
import { EventService } from 'src/app/core/services/event.service';
import { IChatConversation } from 'src/app/shared/models/conversation/chat-conversation';
import { IMessagePreview } from 'src/app/shared/models/messages/message-preview';
import { INewMessage } from 'src/app/shared/models/messages/new-message';

import { defaultImagePath, toDatePreview } from '../chat-utils';

@Component({
  selector: 'app-conversation',
  templateUrl: './conversation.component.html',
  styleUrls: ['../chats.component.sass'],
})
export class ConversationComponent implements OnInit, OnChanges {
  @Input() chatId?: number;

  conversation?: IChatConversation;

  newMessageValue?: string;

  defaultImagePath = defaultImagePath;

  toDatePreview = toDatePreview;

  constructor(
    private chatsService: ChatsService,
    private eventService: EventService,
  ) {}

  ngOnInit(): void {
    this.eventService.newMessageSentEvent$.subscribe(
      (message: IMessagePreview) => {
        this.conversation!.messages = [message, ...this.conversation!.messages];
        this.newMessageValue = '';
      },
    );

    this.eventService.readMessages$.subscribe(() => {
      this.conversation?.messages.forEach((message) => {
        message.isRead = true;
      });
    });
  }

  ngOnChanges({ chatId }: SimpleChanges): void {
    if (chatId.currentValue) {
      this.chatsService
        .getConversationChat(chatId.currentValue)
        .subscribe((conversation: IChatConversation) => {
          this.conversation = conversation;
        });
    }
  }

  identify(index: number, item: IMessagePreview) {
    return item.sentAt;
  }

  sendMessage(value: string) {
    const newMessage: INewMessage = {
      value,
      chatId: this.chatId!,
    };

    this.chatsService
      .addMessage(newMessage)
      .subscribe((message: IMessagePreview) => {
        this.conversation!.messages = [message, ...this.conversation!.messages];
        this.newMessageValue = '';
        this.eventService.receiveNewMessage(message);
      });
  }
}
