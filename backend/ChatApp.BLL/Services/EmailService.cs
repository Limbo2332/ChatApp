using AutoMapper;
using Azure.Communication.Email;
using ChatApp.BLL.Interfaces;
using ChatApp.BLL.Services.Abstract;
using ChatApp.Common.DTO.Mail;
using ChatApp.Common.Logic.Abstract;
using ChatApp.DAL.Context;
using Microsoft.Extensions.Configuration;

namespace ChatApp.BLL.Services
{
    public class EmailService : BaseService, IEmailService
    {
        private readonly EmailClient _emailClient;
        private readonly IConfiguration _config;

        public EmailService(ChatAppContext context, IMapper mapper, IUserIdGetter userIdGetter, EmailClient emailClient, IConfiguration config)
            : base(context, mapper, userIdGetter)
        {
            _emailClient = emailClient;
            _config = config;
        }

        public async Task SendEmailAsync(MailDto mail)
        {
            var sender = _config.GetSection("EmailService:Sender").Value;

            await _emailClient.SendAsync(Azure.WaitUntil.Completed, sender, mail.To, mail.Subject, mail.Content);
        }
    }
}
