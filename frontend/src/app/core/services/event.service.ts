import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { IChatPreview } from 'src/app/shared/models/chats/chat-preview';
import { IChatRead } from 'src/app/shared/models/chats/chat-read';
import { IMessagePreview } from 'src/app/shared/models/messages/message-preview';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  private onInputCleared = new Subject<void>();

  private onNewMessageSent = new Subject<IMessagePreview>();

  private onNewMessageReceived = new Subject<IMessagePreview>();

  private onNewChatCreated = new Subject<IChatPreview>();

  private onReadMessages = new Subject<IChatRead>();

  inputClearedEvent$ = this.onInputCleared.asObservable();

  newMessageSentEvent$ = this.onNewMessageSent.asObservable();

  newMessageReceived$ = this.onNewMessageReceived.asObservable();

  newChatCreatedEvent$ = this.onNewChatCreated.asObservable();

  readMessages$ = this.onReadMessages.asObservable();

  clearInput() {
    this.onInputCleared.next();
  }

  sendNewMessage(message: IMessagePreview) {
    this.onNewMessageSent.next(message);
  }

  receiveNewMessage(message: IMessagePreview) {
    this.onNewMessageReceived.next(message);
  }

  createNewChat(chat: IChatPreview) {
    this.onNewChatCreated.next(chat);
  }

  readMessages(chat: IChatRead) {
    this.onReadMessages.next(chat);
  }
}
