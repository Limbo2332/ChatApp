import { IMessagePreview } from '../messages/message-preview';
import { IUserPreview } from '../user/user-preview';

export interface IChatPreview {
  id: number;
  interlocutor: IUserPreview;
  lastMessage: IMessagePreview;
}
