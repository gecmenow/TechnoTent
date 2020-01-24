using System;
using System.Net;
using System.Net.Mail;
using TechnoTent.Models;

namespace TechnoTent.Mailing
{
    public class UserMail
    {
        public static void RestorePassword(string email)
        {
            try
            {
                var user = User.GetuserInfroByEmail(email);

                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("gec159@gmail.com", "TehnoTent");
                // кому отправляем
                MailAddress to = new MailAddress(email);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to)
                {
                    // тема письма
                    Subject = "Восстановление пароля",// Сделать через ресурсы
                    // текст письма
                    Body = @"<table cellPadding='0' cellSpacing='0' width='850' style='background-color:#d1d1d1;border-radius:2px;border:1px solid #d1d1d1;margin:0 auto' border='1'> <tbody> <tr> <td height='83' width='850' bgcolor='#eaf3f5' style='border:none;padding-top:23px;padding-right:17px;padding-bottom:24px;padding-left:17px'> <table cellPadding='0' cellSpacing='0' width='100%'> <tbody> <tr> <td bgcolor='#ffffff' height='75' style='font-weight:bold;text-align:center;font-size:26px;color:#0b3961'> Магазин ООО 'ТехноТент' </td> </tr> <tr> <td bgcolor='#bad3df' height='11'> </td> </tr> <tr> <td style='text-align:center;'> <img src='~/Content/images/promo__tehno-tent.jpg'> </td> </tr> </tbody> </table> </td> </tr> <tr> <td width='850' bgcolor='#f7f7f7' valign='top' style='border:none;padding-top:0;padding-right:44px;padding-bottom:16px;padding-left:44px'> <p style='margin-top:30px;margin-bottom:28px;font-weight:bold;font-size:19px'> Добрый день," + user.Name + @"</p> <p style='margin-top:0;margin-bottom:20px;line-height:20px;font-size: 18px;line-height: 24px'> Вы или кто-то другой запросили восстановления пароля к учетной записи <b>" + email + @"</b> в интернет-магазине ""ТехноТент"". <br> <br> <span style='font-size: 20px; text-decoration: underline;'>Ваш пароль</span> <br><br> <span style='font-size: 25px; color: #00425f; font-weight: 800'>" + user.Password + @"</span> </p> </td> </tr> <tr> <td height='40px' width='850' bgcolor='#f7f7f7' valign='top' style='border:none;padding-top:0;padding-right:44px;padding-bottom:30px;padding-left:44px'> <p style='border-top:1px solid #d1d1d1;margin-bottom:5px;margin-top:0;padding-top:20px;line-height:21px'> С уважением,<br> администрация <a href='#' style='color:#2e6eb6' target='_blank'>Интернет-магазина ТехноТент</a><br> E-mail: <a href=furnitura@tehnotent.dn.ua style='color:#2e6eb6' target='_blank'>furnitura@tehnotent.dn.ua</a><br> Телефон: +38 (800) 555-35-35 </p> </td> </tr> </tbody> </table>",
                    // письмо представляет код html
                    IsBodyHtml = true,
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