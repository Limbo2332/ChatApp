using ChatApp.Common.DTO.Message;

namespace ChatApp.UnitTests.TestData.Validators.Chat
{
    public class NewMessageValidatorCorrectData : TheoryData<NewMessageDto>
    {
        public NewMessageValidatorCorrectData()
        {
            Add(new NewMessageDto
            {
                ChatId = 1,
                Value = "Hello!"
            });
            Add(new NewMessageDto
            {
                ChatId = 999,
                Value = "Hello, world!"
            });
            Add(new NewMessageDto
            {
                ChatId = 9999,
                Value = "Bye, world!"
            });
        }
    }
}
