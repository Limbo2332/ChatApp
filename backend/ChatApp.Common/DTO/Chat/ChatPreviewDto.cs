using ChatApp.Common.DTO.Message;
using ChatApp.Common.DTO.User;

namespace ChatApp.Common.DTO.Chat
{
    public class ChatPreviewDto
    {
        public int Id { get; set; }

        public UserPreviewDto Interlocutor { get; set; } = null!;

        public MessagePreviewDto LastMessage { get; set; } = null!;

        public int UnreadMessagesCount { get; set; }
    }
}
