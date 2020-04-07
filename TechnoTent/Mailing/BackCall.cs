using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using TechnoTent.Models.ViewModel;

namespace TechnoTent.Mailing
{
    public class BackCall
    {
        public static void SendMail(BackCallVM backCallVM)
        {
            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("tehnotentdn@gmail.com", backCallVM.Name);
                // кому отправляем
                MailAddress to = new MailAddress("tehnotentdn@gmail.com");
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to)
                {
                    // тема письма
                    Subject = "Восстановление пароля",
                    // текст письма
                    Body = @"<table cellPadding='0' cellSpacing='0' width='850' style='background-color:#d1d1d1;border-radius:2px;border:1px solid #d1d1d1;margin:0 auto' border='1'> <tbody> <tr> <td height='83' width='850' bgcolor='#eaf3f5' style='border:none;padding-top:23px;padding-right:17px;padding-bottom:24px;padding-left:17px'> <table cellPadding='0' cellSpacing='0' width='100%'> <tbody> <tr> <td bgcolor='#ffffff' height='75' style='font-weight:bold;text-align:center;font-size:26px;color:#0b3961'> Магазин ООО 'ТехноТент' </td> </tr> <tr> <td bgcolor='#bad3df' height='11'> </td> </tr> <tr> <td style='text-align:center;'><img src='http://tehnotent.com.ua/Content/images/promo__tehno-tent.jpg'> </td> </tr> </tbody> </table> </td> </tr> <tr> <td width='850' bgcolor='#eaf3f5' style='border:none;padding-right:17px;padding-bottom:24px;padding-left:17px'> <p style='margin-bottom:28px;font-weight:bold;font-size:19px'> Обратный звонок </p> <table cellPadding='0' cellSpacing='0' width='100%'> <tbody> <tr><td style='font-size: 18px; text-decoration: underline;line-height: 22px;width: 220px;padding-bottom: 15px'>Имя:</td><td>" + backCallVM.Name + @"</td></tr> <tr><td style='font-size: 18px; text-decoration: underline;line-height: 22px;width: 220px;padding-bottom: 15px'>Мобильный телефон:</td><td>" + backCallVM.Tel + @"</td></tr> <tr><td style='font-size: 18px; text-decoration: underline;line-height: 22px;width: 220px;'>Вопрос или комментарий:</td><td style='line-height: 22px;'>" + backCallVM.Message + @".</td></tr> </tbody> </table> </td> </tr> <tr> <td height='40px' width='850' bgcolor='#f7f7f7' valign='top' style='border:none;padding-top:0;padding-right:44px;padding-bottom:30px;padding-left:44px'> <p style='border-top:1px solid #d1d1d1;margin-bottom:5px;margin-top:0;padding-top:20px;line-height:21px'> С уважением,<br> администрация <a href='' style='color:#2e6eb6' target='_blank'>Интернет-магазина ТехноТент</a><br> E-mail: <a href='tehnotentdn@gmail.com' style='color:#2e6eb6' target='_blank'>tehnotentdn@gmail.com</a><br> Телефон: +38 (050) 512-03-51 </p> </td> </tr> </tbody> </table>",
                    // письмо представляет код html
                    IsBodyHtml = true
                };
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    // логин и пароль
                    Credentials = new NetworkCredential("tehnotentdn@gmail.com", "qpwqullrxqvapwqx"),
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