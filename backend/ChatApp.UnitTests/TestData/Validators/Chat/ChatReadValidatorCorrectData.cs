using ChatApp.Common.DTO.Chat;

namespace ChatApp.UnitTests.TestData.Validators.Chat
{
    public class ChatReadValidatorCorrectData : TheoryData<ChatReadDto>
    {
        public ChatReadValidatorCorrectData()
        {
            Add(new ChatReadDto
            {
                Id = 1,
                UserId = 1
            });
            Add(new ChatReadDto
            {
                Id = 999,
                UserId = 1000
            });
        }
    }
}
