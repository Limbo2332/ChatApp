import { NgModule } from '@angular/core';

import { SharedModule } from '../../shared.module';
import { ChatRoutingModule } from './chat-routing.module';
import { ChatComponent } from './chat/chat.component';
import { ChatsComponent } from './chats/chats.component';
import { ConversationComponent } from './conversation/conversation.component';

@NgModule({
  declarations: [ChatsComponent, ChatComponent, ConversationComponent],
  imports: [ChatRoutingModule, SharedModule],
})
export class ChatModule {}
