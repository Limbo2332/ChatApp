import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { ChatsService } from 'src/app/core/services/chats.service';
import { IChatConversation } from 'src/app/shared/models/conversation/chat-conversation';

import { defaultImagePath, toDatePreview } from '../chat-utils';

@Component({
  selector: 'app-conversation',
  templateUrl: './conversation.component.html',
  styleUrls: ['../chats.component.sass'],
})
export class ConversationComponent implements OnChanges {
  @Input() chatId?: number;

  conversation?: IChatConversation;

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
}
