import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, switchMap, throwError } from 'rxjs';

import { AuthService } from '../services/auth.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  private isRefreshed = false;

  constructor(private authService: AuthService) {}

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
        if (error.status === 401) {
          return this.refreshTokensOn401Request(newReq, next);
        }

        return throwError(error.error.errors);
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
        catchError((error) => {
          this.isRefreshed = false;

          return throwError(() => error);
        }),
      );
    }

    return next.handle(request);
  }
}
