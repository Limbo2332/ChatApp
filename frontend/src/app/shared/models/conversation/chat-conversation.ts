import { IMessagePreview } from '../messages/message-preview';
import { IUserPreview } from '../user/user-preview';

export interface IChatConversation {
  chatId: number;
  interlocutor: IUserPreview;
  messages: IMessagePreview[];
}
