import { Component, Input } from '@angular/core';
import { IChatPreview } from 'src/app/shared/models/chats/chat-preview';

import { defaultImagePath, toDatePreview } from '../chat-utils';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['../chats.component.sass'],
})
export class ChatComponent {
  @Input() chat: IChatPreview;

  defaultImagePath = defaultImagePath;

  toDatePreview = toDatePreview;
}
