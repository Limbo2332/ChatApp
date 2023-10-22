namespace ChatApp.Common.DTO.Message
{
    public class LastMessagePreviewDto
    {
        public bool IsMine { get; set; }

        public string Value { get; set; } = string.Empty;

        public DateTime SentAt { get; set; }
    }
}
