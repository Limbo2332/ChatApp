export const minChatsWidth = 200;
export const minConversationsWidth = 300;

export const defaultImagePath = 'assets/default-image.png';

export function toDatePreview(dateString: Date): string {
  const now = new Date();
  const date = new Date(dateString);

  const dateDifference =
    Date.UTC(now.getFullYear(), now.getMonth(), now.getDate()) -
    Date.UTC(date.getFullYear(), date.getMonth(), date.getDate());

  const daysDifference = Math.floor(dateDifference / (1000 * 60 * 60 * 24));

  if (daysDifference >= 1) {
    return date.toLocaleDateString();
  }

  return date.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
}
