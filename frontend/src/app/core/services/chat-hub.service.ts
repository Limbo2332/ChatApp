import { Injectable } from '@angular/core';
import { HubConnectionBuilder } from '@microsoft/signalr';
import { IChatPreview } from 'src/app/shared/models/chats/chat-preview';
import { IMessagePreview } from 'src/app/shared/models/messages/message-preview';
import { IUser } from 'src/app/shared/models/user/user';
import { environment } from 'src/environments/environment';

import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class ChatHubService {
  private currentUser: IUser;

  constructor(private authService: AuthService) {
    this.authService.getUser().subscribe((user: IUser) => {
      this.currentUser = user;
    });
  }

  async startConnection() {
    const connection = new HubConnectionBuilder()
      .withUrl(`${environment.apiUrl}/chathub`)
      .withAutomaticReconnect()
      .build();

    await connection.start();

    await connection.invoke(
      'OnConnectionAsync',
      this.currentUser.id.toString(),
    );

    connection.on('sendNewMessageAsync', (message: IMessagePreview) => {
      console.log(message);
    });

    connection.on('createNewChatAsync', (chat: IChatPreview) => {
      console.log(chat);
    });
  }
}
