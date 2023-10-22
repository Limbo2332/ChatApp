import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IChatPreview } from 'src/app/shared/models/chats/chat-preview';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ChatsService {
  private baseUrl: string = `${environment.apiUrl}/chats`;

  constructor(private http: HttpClient) {}

  getChats(): Observable<IChatPreview[]> {
    return this.http.get<IChatPreview[]>(this.baseUrl);
  }
}
