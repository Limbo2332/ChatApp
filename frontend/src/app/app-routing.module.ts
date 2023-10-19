import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { authenticatedGuard } from './core/guards/authenticated.guard';

const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./shared/modules/main/main.module').then((i) => i.MainModule),
  },
  {
    path: 'auth',
    loadChildren: () =>
      import('./shared/modules/auth/auth.module').then((i) => i.AuthModule),
  },
  {
    path: 'chats',
    loadChildren: () =>
      import('./shared/modules/chat/chat.module').then((i) => i.ChatModule),
    canActivate: [authenticatedGuard],
  },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
