import { Injectable } from '@angular/core';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { IChatPreview } from 'src/app/shared/models/chats/chat-preview';
import { IChatRead } from 'src/app/shared/models/chats/chat-read';
import { IMessagePreview } from 'src/app/shared/models/messages/message-preview';
import { IUser } from 'src/app/shared/models/user/user';
import { environment } from 'src/environments/environment';

import { AuthService } from './auth.service';
import { EventService } from './event.service';

@Injectable({
  providedIn: 'root',
})
export class ChatHubService {
  private currentUser: IUser;

  constructor(
    private authService: AuthService,
    private eventService: EventService,
  ) {
    this.getUser();
  }

  async startConnection() {
    const connection = new HubConnectionBuilder()
      .withUrl(`${environment.apiUrl}/chathub`)
      .configureLogging(LogLevel.Warning)
      .withAutomaticReconnect()
      .build();

    await connection.start();

    await connection.invoke(
      'OnConnectionAsync',
      this.currentUser.id.toString(),
    );

    connection.on('sendNewMessageAsync', (message: IMessagePreview) => {
      this.eventService.sendNewMessage(message);
    });

    connection.on('createNewChatAsync', (chat: IChatPreview) => {
      this.eventService.createNewChat(chat);
    });

    connection.on('readMessagesAsync', (chat: IChatRead) => {
      this.eventService.readMessages(chat);
    });
  }

  private getUser() {
    this.authService.getUser().subscribe((user: IUser) => {
      this.currentUser = user;
    });
  }
}
