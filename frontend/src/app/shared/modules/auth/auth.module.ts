import { NgModule } from '@angular/core';

import { SharedModule } from '../../shared.module';
import { AuthRoutingModule } from './auth-routing.module';
import { ResetComponent } from './reset/reset.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';

@NgModule({
  declarations: [SignInComponent, SignUpComponent, ResetComponent],
  imports: [SharedModule, AuthRoutingModule],
})
export class AuthModule {}
