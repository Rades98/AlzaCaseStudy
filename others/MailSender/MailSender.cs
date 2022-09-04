using System.Net;
using System.Net.Mail;
using System.Reflection;

namespace MailSender
{
	public static class MailSender
	{
		public static void SendRegistrationEmail(string reciever, string code, string name)
		{
			try
			{
				var smtp = new SmtpClient
				{
					Host = "smtp.gmail.com",
					Port = 587,
					EnableSsl = true,
					DeliveryMethod = SmtpDeliveryMethod.Network,
					UseDefaultCredentials = false,
					//Credentials = new NetworkCredential("casestudyeshop@gmail.com", "HeSOYzam789?das2")
					Credentials = new NetworkCredential("casestudyeshop@gmail.com", "udacxqtvtblzfzgd")
				};

				// add from,to mailaddresses
				MailAddress from = new MailAddress("casestudyeshop@gmail.com", "CaseStudy - no reply");
				MailAddress to = new MailAddress(reciever, "TestToName");
				MailMessage myMail = new MailMessage(from, to);

				// set subject and encoding
				myMail.Subject = $"User registration for {name}";
				myMail.SubjectEncoding = System.Text.Encoding.UTF8;

				string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location!)!, @"MessagesHtml\ConfirmRegistration.html");
				string body = File.ReadAllText(path);

				body = body.Replace("{code}", code);

				// set body-message and encoding
				myMail.Body = body;
				myMail.BodyEncoding = System.Text.Encoding.UTF8;
				// text or html
				myMail.IsBodyHtml = true;

				smtp.Send(myMail);
			}

			catch (SmtpException ex)
			{
				throw ex;
			}
		}
	}
}