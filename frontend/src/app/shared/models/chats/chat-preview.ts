import { ILastMessagePreview } from '../messages/last-message-preview';
import { IUserPreview } from '../user/user-preview';

export interface IChatPreview {
  id: number;
  interlocutor: IUserPreview;
  lastMessage: ILastMessagePreview;
}
