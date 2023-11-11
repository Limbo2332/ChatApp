import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, Observable, switchMap, throwError } from 'rxjs';
import { ErrorCode } from 'src/app/shared/models/enums/errorcode';

import { AuthService } from '../services/auth.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  private isRefreshed = false;

  constructor(
    private authService: AuthService,
    private router: Router,
  ) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler,
  ): Observable<HttpEvent<unknown>> {
    const token = this.authService.getUserToken();

    let newReq = request;

    if (token) {
      newReq = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`,
        },
      });
    }

    return next.handle(newReq).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status === 401 && !error.error) {
          return this.refreshTokensOn401Request(newReq, next);
        }

        if (
          (error.error &&
            error.error.code &&
            error.error.code === ErrorCode.InvalidToken) ||
          error.error.code === ErrorCode.ExpiredRefreshToken
        ) {
          this.authService.logout();
          this.router.navigate(['/']);

          return throwError([error.error.error]);
        }

        if (error.error.code) {
          return throwError([error.error.error]);
        }

        return throwError(error.error?.errors ?? []);
      }),
    );
  }

  private refreshTokensOn401Request(
    request: HttpRequest<unknown>,
    next: HttpHandler,
  ) {
    if (this.isRefreshed) {
      return next.handle(request);
    }

    this.isRefreshed = true;

    if (this.authService.isAuthenticated) {
      return this.authService.refreshToken().pipe(
        switchMap(() => {
          this.isRefreshed = false;

          return next.handle(request);
        }),
        catchError((error: HttpErrorResponse) => {
          this.isRefreshed = false;

          return throwError(() => [error.error.error]);
        }),
      );
    }

    return next.handle(request);
  }
}
