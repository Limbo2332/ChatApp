import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IChatPreview } from 'src/app/shared/models/chats/chat-preview';
import { IChatRead } from 'src/app/shared/models/chats/chat-read';
import { INewChat } from 'src/app/shared/models/chats/new-chat';
import { IChatConversation } from 'src/app/shared/models/conversation/chat-conversation';
import { IMessagePreview } from 'src/app/shared/models/messages/message-preview';
import { INewMessage } from 'src/app/shared/models/messages/new-message';
import { IPageSettings } from 'src/app/shared/models/page/page-settings';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ChatsService {
  private baseUrl: string = `${environment.apiUrl}/chats`;

  constructor(private http: HttpClient) {}

  getChats(pageSettings?: IPageSettings): Observable<IChatPreview[]> {
    return this.http.get<IChatPreview[]>(this.baseUrl, {
      params: this.getPageParams(pageSettings),
    });
  }

  getConversationChat(
    chatId: number,
    pageSettings?: IPageSettings,
  ): Observable<IChatConversation> {
    return this.http.get<IChatConversation>(`${this.baseUrl}/${chatId}`, {
      params: this.getPageParams(pageSettings),
    });
  }

  addMessage(newMessage: INewMessage): Observable<IMessagePreview> {
    return this.http.post<IMessagePreview>(
      `${this.baseUrl}/message`,
      newMessage,
    );
  }

  addChat(newChat: INewChat): Observable<IChatPreview> {
    return this.http.post<IChatPreview>(this.baseUrl, newChat);
  }

  readMessages(chatRead: IChatRead): Observable<void> {
    return this.http.patch<void>(`${this.baseUrl}/messages`, chatRead);
  }

  private getPageParams(pageSettings?: IPageSettings): HttpParams {
    let queryParams = new HttpParams();

    if (!pageSettings) {
      return queryParams;
    }

    if (pageSettings.filter) {
      queryParams = queryParams
        .append('filter.propertyName', pageSettings.filter.propertyName)
        .append('filter.propertyValue', pageSettings.filter.propertyValue);
    }

    if (pageSettings.pagination) {
      queryParams = queryParams
        .append(
          'pagination.pageNumber',
          pageSettings.pagination.pageNumber.toString(),
        )
        .append(
          'pagination.pageSize',
          pageSettings.pagination.pageSize.toString(),
        );
    }

    return queryParams;
  }
}
