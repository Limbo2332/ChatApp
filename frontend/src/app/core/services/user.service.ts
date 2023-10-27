import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from 'src/app/shared/models/user/user';
import { IUserAvatar } from 'src/app/shared/models/user/user-avatar';
import { IUserEdit } from 'src/app/shared/models/user/user-edit';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private baseUrl: string = `${environment.apiUrl}/users`;

  constructor(private http: HttpClient) {}

  updateAvatar(form: FormData): Observable<IUserAvatar> {
    return this.http.post<IUserAvatar>(`${this.baseUrl}/avatar`, form);
  }

  update(user: IUserEdit): Observable<IUser> {
    return this.http.put<IUser>(this.baseUrl, user);
  }
}
