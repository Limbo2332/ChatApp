import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private baseUrl: string = `${environment.apiUrl}/users`;

  constructor(private http: HttpClient) {}

  updateAvatar(form: FormData): Observable<string> {
    return this.http.post<string>(`${this.baseUrl}/avatar`, form);
  }
}
