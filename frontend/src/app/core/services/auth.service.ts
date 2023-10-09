import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private baseUrl = `${environment.apiUrl}/auth`;

  private userSubject: BehaviorSubject<string | undefined>;

  private user?: string;

  constructor(private http: HttpClient) {
    this.userSubject = new BehaviorSubject(
      JSON.parse(localStorage.getItem('user')!),
    );

    this.user = this.userSubject.value;
  }

  register(email: string, username: string, password: string) {
    return this.http
      .post<string>(`${this.baseUrl}/register`, {
        email,
        username,
        password,
      })
      .pipe(
        map((resp: string) => {
          localStorage.setItem('user', JSON.stringify(resp));
          this.userSubject.next(resp);

          return resp;
        }),
      );
  }

  get isAuthenticated() {
    return !!this.user;
  }

  getUser(): Observable<string> {
    return of(this.user!);
  }

  getUserToken(): string | undefined {
    return this.user;
  }

  logout() {
    localStorage.removeItem('user');
    this.userSubject.next(undefined);
  }
}
