export const minChatsWidth = 300;
export const minConversationsWidth = 300;

export const defaultImagePath = 'assets/default-image.png';

export function toDatePreview(dateString: Date): string {
  const now = new Date();
  const date = new Date(dateString);

  const dateDifference =
    Date.UTC(now.getFullYear(), now.getMonth(), now.getDate()) -
    Date.UTC(date.getFullYear(), date.getMonth(), date.getDate());

  const daysDifference = Math.floor(dateDifference / (1000 * 60 * 60 * 24));

  if (daysDifference >= 7) {
    return date.toLocaleDateString();
  }

  if (daysDifference >= 1) {
    return date.toLocaleDateString(['en-US'], { weekday: 'short' });
  }

  return date.toLocaleTimeString(['en-US'], {
    hour: '2-digit',
    minute: '2-digit',
  });
}
