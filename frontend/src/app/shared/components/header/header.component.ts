import { Component } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';

import { routerLinkActiveOptions } from './header-utils';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.sass'],
})
export class HeaderComponent {
  isAuthenticated: boolean;

  routerLinkActiveOptions = routerLinkActiveOptions;

  constructor(private authService: AuthService) {
    this.isAuthenticated = this.authService.isAuthenticated;
  }
}
