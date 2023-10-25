export interface IMessagePreview {
  isMine: boolean;
  isRead: boolean;
  value: string;
  sentAt: Date;
  chatId: number;
}
