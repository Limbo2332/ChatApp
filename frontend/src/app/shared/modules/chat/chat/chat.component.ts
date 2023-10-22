import { Component, OnInit } from '@angular/core';
import { ResizeEvent } from 'angular-resizable-element';
import { ChatsService } from 'src/app/core/services/chats.service';
import { IChatPreview } from 'src/app/shared/models/chats/chat-preview';

import { minChatsWidth, minConversationsWidth } from './chat-utils';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.sass'],
})
export class ChatComponent implements OnInit {
  chatStyles: object = {
    'width.px': minChatsWidth * 3,
    'min-width.px': minChatsWidth,
    'max-width.px': window.innerWidth - minConversationsWidth,
  };

  conversationStyles: object = {
    'width.px': window.innerWidth - minChatsWidth * 3,
    'min-width.px': minConversationsWidth,
    'max-width.px': window.innerWidth - minChatsWidth,
  };

  chats: IChatPreview[] = [];

  constructor(private chatsService: ChatsService) {}

  ngOnInit(): void {
    this.chatsService.getChats().subscribe((chats: IChatPreview[]) => {
      this.chats = chats;
    });
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
}
