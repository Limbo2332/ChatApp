using ChatApp.Common.DTO.Mail;

namespace ChatApp.BLL.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailDto mail);
    }
}
