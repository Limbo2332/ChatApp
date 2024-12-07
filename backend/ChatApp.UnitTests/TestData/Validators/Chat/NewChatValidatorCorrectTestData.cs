using ChatApp.Common.DTO.Chat;

namespace ChatApp.UnitTests.TestData.Validators.Chat
{
    public class NewChatValidatorCorrectTestData : TheoryData<NewChatDto>
    {
        public NewChatValidatorCorrectTestData()
        {
            Add(new NewChatDto
            {
                NewMessage = "Hello, world!",
                UserName = "Valentyn"
            });
            Add(new NewChatDto
            {
                NewMessage = "Bye!",
                UserName = "Oleksii"
            });
            Add(new NewChatDto
            {
                NewMessage = "I forgot to say you!",
                UserName = "Oleksandr"
            });
        }
    }
}
