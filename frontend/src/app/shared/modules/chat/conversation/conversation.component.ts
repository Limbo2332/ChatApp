import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  Output,
  SimpleChanges,
} from '@angular/core';
import { ChatsService } from 'src/app/core/services/chats.service';
import { IChatConversation } from 'src/app/shared/models/conversation/chat-conversation';
import { IMessagePreview } from 'src/app/shared/models/messages/message-preview';
import { INewMessage } from 'src/app/shared/models/messages/new-message';

import { defaultImagePath, toDatePreview } from '../chat-utils';

@Component({
  selector: 'app-conversation',
  templateUrl: './conversation.component.html',
  styleUrls: ['../chats.component.sass'],
})
export class ConversationComponent implements OnChanges {
  @Input() chatId?: number;

  @Output() newMessageSent = new EventEmitter<IMessagePreview>();

  conversation?: IChatConversation;

  newMessageValue?: string;

  defaultImagePath = defaultImagePath;

  toDatePreview = toDatePreview;

  constructor(private chatsService: ChatsService) {}

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

        this.newMessageSent.emit(message);
      });
  }
}
