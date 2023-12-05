using Azure;
using Azure.Communication.Email;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Services;
using ChatApp.Common.DTO.Mail;
using ChatApp.UnitTests.Systems.Services.Abstract;

namespace ChatApp.UnitTests.Systems.Services
{
    public class EmailServiceTests : BaseServiceTests
    {
        private readonly IEmailService _sut;
        private readonly EmailClient _emailClient;

        public EmailServiceTests()
        {
            _emailClient = Substitute.For<EmailClient>();

            _sut = new EmailService(_mapper, _userIdGetterMock.Object, _emailClient, _configMock.Object);
        }

        [Fact]
        public async Task SendEmailAsync_Should_ReturnEmailOperation()
        {
            // Arrange
            var mailDto = Substitute.For<MailDto>();
            var sender = "sender";
            var emailSendOperation = new EmailSendOperation("1", _emailClient);

            _configMock
                .Setup(c => c.GetSection(It.IsAny<string>()).Value)
                .Returns(sender);

            _emailClient
                .SendAsync(Arg.Any<WaitUntil>(), sender, Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>())
                .Returns(emailSendOperation);

            // Act
            var result = await _sut.SendEmailAsync(mailDto);

            // Assert
            result.Should().BeEquivalentTo(emailSendOperation);
            _emailClient.ReceivedCalls().Count().Should().Be(1);
;        }
    }
}
