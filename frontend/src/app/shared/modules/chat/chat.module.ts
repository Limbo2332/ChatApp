import { NgModule } from '@angular/core';

import { SharedModule } from '../../shared.module';
import { ChatRoutingModule } from './chat-routing.module';
import { ChatComponent } from './chat/chat.component';

@NgModule({
  declarations: [ChatComponent],
  imports: [ChatRoutingModule, SharedModule],
})
export class ChatModule {}
