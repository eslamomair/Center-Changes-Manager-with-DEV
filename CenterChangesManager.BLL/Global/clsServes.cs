using CenterChangesManager.DAL.Global;
using MailKit.Net.Smtp;
using MimeKit;
using System.Configuration;
using System.Data;

namespace CenterChangesManager.BLL.Global
{
    public class clsServes
    {

        public static int GetActiveChangesCount()
        {
            return clsServesData.GetActiveChangesCount();
        }


        public static int GetCountByType(int typeID)
        {
            return clsServesData.GetActiveChangesCountByType(typeID);
        }

        public static DataTable GetCountWithName()
        {
            return clsServesData.GetCountWithName();
        }



        public static string CreateOTP()
        {
            Random random = new Random();
            int otp = random.Next(100000, 999999);
            return otp.ToString();


        }


        public static Common.ChangeCounts LoadCount()
        {

            return clsServesData.GetAllCounts();
        }


        public static async Task<bool> SendOtpEmailAsync(string targetEmail, string otpCode)
        {
            try
            {
                string? senderEmail = ConfigurationManager.AppSettings["SenderEmail"];
                string? senderName = ConfigurationManager.AppSettings["SenderName"];
                string? smtpHost = ConfigurationManager.AppSettings["BrevoSmtpServer"];
                int smtpPort = int.Parse(ConfigurationManager.AppSettings["BrevoPort"] ?? "587");

                string? smtpUsername = ConfigurationManager.AppSettings["BrevoLogin"];
                string? smtpPassword = ConfigurationManager.AppSettings["BrevoPassword"];

                if (string.IsNullOrEmpty(senderEmail) || string.IsNullOrEmpty(smtpHost) ||
                    string.IsNullOrEmpty(smtpUsername) || string.IsNullOrEmpty(smtpPassword))
                {
                    throw new Exception("إعدادات البريد الإلكتروني غير مكتملة في ملف التكوين.");
                }

                var message = new MimeMessage();
                // 1. بيانات المرسل (اسمك والإيميل المسجل في Brevo)
                message.From.Add(new MailboxAddress(senderName, senderEmail));

                message.To.Add(new MailboxAddress("", targetEmail));
                message.Subject = "رمز التحقق (OTP)";
                message.Body = new TextPart("plain")
                {
                    Text = $"مرحباً، رمز التحقق الخاص بك هو: {otpCode}"
                };

                using (var client = new SmtpClient())
                {
                    // 2. الاتصال بخادم Brevo بدلاً من جوجل
                    await client.ConnectAsync(smtpHost, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);

                    // 3. تسجيل الدخول باستخدام الـ Login والـ Master Password من Brevo
                    await client.AuthenticateAsync(smtpUsername, smtpPassword);

                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("فشل في إرسال البريد الإلكتروني: " + ex.Message);
            }
        }
    }
}
