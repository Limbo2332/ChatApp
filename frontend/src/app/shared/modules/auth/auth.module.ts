import { NgModule } from '@angular/core';

import { SharedModule } from '../../shared.module';
import { AuthRoutingModule } from './auth-routing.module';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';

@NgModule({
  declarations: [SignInComponent, SignUpComponent],
  imports: [SharedModule, AuthRoutingModule],
})
export class AuthModule {}
