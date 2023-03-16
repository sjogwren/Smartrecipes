using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartReservation.Utils
{
    public class EmailBusiness
    {
        public bool PasswordChange(string emailBody, string to)
        {
            var m = new MailMessage()
            {
                Subject = "Password Change - Complete",
                Body = emailBody,
                IsBodyHtml = true,
            };
            m.From = new MailAddress("21122173@dut4life.ac.za", "Smart Reservations");
            m.To.Add(to);
            SmtpClient smtp = new SmtpClient()
            {
                Host = "pod51014.outlook.com",
                Port = 587,
                Credentials = new System.Net.NetworkCredential("21122173@dut4life.ac.za", "Dut920924"),
                EnableSsl = true
            };
            try
            {
                smtp.Send(m);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
