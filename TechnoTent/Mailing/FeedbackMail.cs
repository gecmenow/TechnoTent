using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Mailing
{
    public class FeedbackMail
    {
        public static void SendMail(FeedbackVM feedbackVM)
        {
            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("gector456@gmail.com", feedbackVM.Name);
                // кому отправляем
                MailAddress to = new MailAddress("gec159@gmail.com");
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to)
                {
                    // тема письма
                    Subject = "Обратная связь",
                    // текст письма
                    Body = "<h2>Письмо-тест работы smtp-клиента</h2>",
                    // письмо представляет код html
                    IsBodyHtml = true
                };
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    // логин и пароль
                    Credentials = new NetworkCredential("gec159@gmail.com", "yyqmbadoxlkotamq"),
                    EnableSsl = true
                };

                smtp.Send(m);

                smtp.Dispose();

            }
            catch (Exception)
            {
               
            }
        }
    }
}