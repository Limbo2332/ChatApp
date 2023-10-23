import { Component, OnInit } from '@angular/core';
import { ResizeEvent } from 'angular-resizable-element';
import { ChatsService } from 'src/app/core/services/chats.service';
import { IChatPreview } from 'src/app/shared/models/chats/chat-preview';

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

  private activeChatName = 'activeChat';

  constructor(private chatsService: ChatsService) {}

  ngOnInit(): void {
    this.removeActiveChat();
    this.chatsService.getChats().subscribe((chats: IChatPreview[]) => {
      this.chats = chats;
    });
  }

  selectChat(chatId: number) {
    localStorage.setItem(this.activeChatName, chatId.toString());
    this.selectedChatId = chatId;
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
}
