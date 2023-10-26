import { NgModule } from '@angular/core';

import { SharedModule } from '../../shared.module';
import { UserProfileRoutingModule } from './user-profile-routing.module';
import { UserProfileComponent } from './user-profile/user-profile.component';

@NgModule({
  declarations: [UserProfileComponent],
  imports: [SharedModule, UserProfileRoutingModule],
})
export class UserProfileModule {}
