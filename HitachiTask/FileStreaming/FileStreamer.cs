using System.Net;
using System.Net.Mail;
using System.Text;

namespace HitachiTask.FileStreaming
{
    public static class FileStreamer
    {
        public static void SendDirectlyToEmail(string[][] table, string senderEmail, string senderPassword,
            string recipientEmail, bool isEnglish, int bestDay)
        {
            StringBuilder csvContent = new StringBuilder();
            foreach (var array in table)
            {
                string line = String.Join(",", array);
                csvContent = csvContent.AppendLine(line);
            }
            string addOn = "";
            if (bestDay == 1 || bestDay == 31)
            {
                addOn = "st";
            }
            else if(bestDay == 2)
            {
                addOn = "nd";
            }
            else if(bestDay == 3)
            {
                addOn = "rd";
            }
            else
            {
                addOn = "th";
            }
            using (MemoryStream stream = new MemoryStream())
            {
                byte[] csvBytes = Encoding.UTF8.GetBytes(csvContent.ToString());
                stream.Write(csvBytes, 0, csvBytes.Length);

                stream.Position = 0;

                Attachment attachment = new Attachment(stream, "WeatherReport.csv", "text/csv");

                MailMessage message = new MailMessage();
                message.Attachments.Add(attachment);

                message.From = new MailAddress(senderEmail);
                message.To.Add(recipientEmail);
                if(isEnglish)
                {
                    message.Subject = "Hitachi Space Program by Ivaylo Stamov";
                    message.Body = "Hello," +
                        "\n" +
                        $"\nHere you will find attached the CSV file. Also the {bestDay}{addOn} is the best day for a flight." +
                        "\n" +
                        "\nBest regards," +
                        "\nIvaylo Stamov";
                }
                else
                {
                    message.Subject = "Hitachi Space Program von Ivaylo Stamov";
                    message.Body = "Hallo," +
                        "\n" +
                        $"\nHier finden Sie im Anhang die CSV-Datei. Außerdem ist der {bestDay}te der beste Tag für einen Flug." +
                        "\n" +
                        "\nMit freundlichen Grüßen," +
                        "\nIvaylo Stamov";
                }

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

                try
                {
                    smtpClient.Send(message);
                    if(isEnglish)
                    {
                        Console.WriteLine("Email sent successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Email wurde erfolgreich Versendet.");
                    }
                }
                catch (Exception ex)
                {
                    if(isEnglish)
                    {
                        Console.WriteLine("Failed to send email: " + ex.Message);
                    }
                    {
                        Console.WriteLine("E-Mail konnte nicht gesendet werden: " + ex.Message);
                    }
                }
                finally
                {
                    attachment.Dispose();
                    message.Dispose();
                    smtpClient.Dispose();
                }
            }
        }
    }
}
