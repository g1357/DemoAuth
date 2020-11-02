using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    /// <summary>
    /// Сервис отправки электронной почты
    /// </summary>
    public class EmailSender : IEmailSender
    {
        // Переменные конфигурации
        private string _host;        // Почтовый сервер
        private int _port;           // Порт
        private bool _enableSSL;     // разрешение SSL
        private string _userName;    // Имя пользователя 
        private string _password;    // Пароль

        public EmailSender(string host, int port,
            bool enableSSL, string userName, string password)
        {
            _host = host;
            _port = port;
            _enableSSL = enableSSL;
            _userName = userName;
            _password = password;
        }

        /// <summary>
        /// Асинхронная отправка электронного письма
        /// </summary>
        /// <param name="email">Адрес получателя</param>
        /// <param name="subject">Тема письма</param>
        /// <param name="htmlMessage">Тело письма в формате HTML</param>
        /// <returns>нет</returns>
        public Task SendEmailAsync(string email, 
            string subject, string htmlMessage)
        {
            var client = new SmtpClient(_host, _port)
            {
                Credentials = new NetworkCredential(_userName, _password),
                EnableSsl = _enableSSL
            };
            return client.SendMailAsync(
                new MailMessage(_userName, email, subject, htmlMessage)
                { IsBodyHtml = true}
            );
        }
    }
}
