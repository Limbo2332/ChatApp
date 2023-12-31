import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';

import { IUser } from '../../models/user/user';
import { defaultImagePath } from '../../modules/chat/chat-utils';
import { routerLinkActiveOptions } from './header-utils';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.sass'],
})
export class HeaderComponent implements OnInit {
  isAuthenticated: boolean;

  routerLinkActiveOptions = routerLinkActiveOptions;

  defaultImagePath = defaultImagePath;

  user?: IUser;

  constructor(
    private authService: AuthService,
    private router: Router,
  ) {
    this.isAuthenticated = this.authService.isAuthenticated;
  }

  ngOnInit(): void {
    if (this.isAuthenticated) {
      this.getCurrentUser();
    }
  }

  logout() {
    this.authService.logout();

    this.router.navigate(['auth', 'login']);
  }

  private getCurrentUser() {
    this.authService.getUser().subscribe((user: IUser) => {
      this.user = user;
    });
  }
}
