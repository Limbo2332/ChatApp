import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IResetEmail } from 'src/app/shared/models/mail/reset-email';
import { IBlobImage } from 'src/app/shared/models/user/blob-image';
import { IResetPassword } from 'src/app/shared/models/user/reset-password';
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

  updateSqlAvatar(form: FormData): Observable<IBlobImage> {
    return this.http.post<IBlobImage>(`${this.baseUrl}/sql-avatar`, form);
  }

  sendResetPasswordEmail(resetEmail: IResetEmail): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/send-reset-email`, resetEmail);
  }

  resetPassword(resetPassword: IResetPassword): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/reset`, resetPassword);
  }

  update(user: IUserEdit): Observable<IUser> {
    return this.http.put<IUser>(this.baseUrl, user);
  }
}
