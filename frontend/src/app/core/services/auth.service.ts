import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable, of } from 'rxjs';
import { IAccessToken } from 'src/app/shared/models/token/access-token';
import { IAuthUser } from 'src/app/shared/models/user/auth-user';
import { IUser } from 'src/app/shared/models/user/user';
import { IUserLogin } from 'src/app/shared/models/user/user-login';
import { IUserRegister } from 'src/app/shared/models/user/user-register';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private baseUrl = `${environment.apiUrl}/auth`;

  private userSubject: BehaviorSubject<IUser | undefined>;

  private user?: IUser;

  private userKeyName = 'user';

  private accessTokenKeyName = 'userAccessToken';

  private refreshTokenKeyName = 'userRefreshToken';

  constructor(private http: HttpClient) {
    const userFromStorage = localStorage.getItem(this.userKeyName);
    const initialUser = userFromStorage
      ? JSON.parse(userFromStorage)
      : undefined;

    this.userSubject = new BehaviorSubject<IUser | undefined>(initialUser);
    this.user = this.userSubject.value;
  }

  setUserInfo(user: IUser) {
    localStorage.setItem(this.userKeyName, JSON.stringify(user));
    this.userSubject.next(user);
    this.user = user;
  }

  login(user: IUserLogin): Observable<IAuthUser> {
    return this.handleAuthResponse(
      this.http.post<IAuthUser>(`${this.baseUrl}/login`, user),
    );
  }

  register(user: IUserRegister): Observable<IAuthUser> {
    return this.handleAuthResponse(
      this.http.post<IAuthUser>(`${this.baseUrl}/register`, user),
    );
  }

  refreshToken(): Observable<IAccessToken> {
    const token: IAccessToken = {
      accessToken: localStorage.getItem(this.accessTokenKeyName)!,
      refreshToken: localStorage.getItem(this.refreshTokenKeyName)!,
    };

    return this.http.post<IAccessToken>(`${this.baseUrl}/refresh`, token).pipe(
      map((resp: IAccessToken) => {
        this.setTokensInfo(resp);

        return resp;
      }),
    );
  }

  removeRefreshToken(): void {
    const refreshToken = localStorage.getItem(this.refreshTokenKeyName)!;

    this.http
      .delete<void>(`${this.baseUrl}/removetoken`, {
        params: {
          refreshToken,
        },
      })
      .subscribe();
  }

  get isAuthenticated() {
    return !!this.user;
  }

  getUser(): Observable<IUser> {
    return of(this.user!);
  }

  getUserToken(): string | null {
    return localStorage.getItem(this.accessTokenKeyName);
  }

  logout() {
    this.removeRefreshToken();
    this.removeTokensInfo();

    localStorage.removeItem(this.userKeyName);
    this.user = undefined;
    this.userSubject.next(undefined);
  }

  private handleAuthResponse(
    authRequest: Observable<IAuthUser>,
  ): Observable<IAuthUser> {
    return authRequest.pipe(
      map((response) => {
        this.setUserInfo(response.user);
        this.setTokensInfo(response.token);

        return response;
      }),
    );
  }

  private setTokensInfo(token: IAccessToken) {
    localStorage.setItem(this.accessTokenKeyName, token.accessToken);
    localStorage.setItem(this.refreshTokenKeyName, token.refreshToken);
  }

  private removeTokensInfo() {
    localStorage.removeItem(this.accessTokenKeyName);
    localStorage.removeItem(this.refreshTokenKeyName);
  }
}
