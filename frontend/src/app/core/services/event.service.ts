import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { IChatPreview } from 'src/app/shared/models/chats/chat-preview';
import { IMessagePreview } from 'src/app/shared/models/messages/message-preview';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  private onInputCleared = new Subject<void>();

  private onNewMessageSent = new Subject<IMessagePreview>();

  private onNewChatCreated = new Subject<IChatPreview>();

  inputClearedEvent$ = this.onInputCleared.asObservable();

  newMessageSentEvent$ = this.onNewMessageSent.asObservable();

  newChatCreatedEvent$ = this.onNewChatCreated.asObservable();

  clearInput() {
    this.onInputCleared.next();
  }

  sendNewMessage(message: IMessagePreview) {
    this.onNewMessageSent.next(message);
  }

  createNewChat(chat: IChatPreview) {
    this.onNewChatCreated.next(chat);
  }
}
