using Azure.Communication.Email;
using ChatApp.Common.DTO.Mail;

namespace ChatApp.BLL.Interfaces
{
    public interface IEmailService
    {
        Task<EmailSendOperation> SendEmailAsync(MailDto mail);
    }
}
