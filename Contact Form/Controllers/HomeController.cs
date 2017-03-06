using Contact_Form.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Contact_Form.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactFormViewModel model)
        {
            if(ModelState.IsValid)
            {
                ViewBag.Success = true;
                ViewBag.SubmitMessage = "Thank you for your feedback.";

                var toAddress = "themarshallmiller@gmail.com"; // TODO: Move this to a config setting
                var fromAddress = model.Email;
                var subject = model.Subject;
                var message = new StringBuilder();
                message.Append("Name: " + model.FirstName + "\n");
                message.Append("Message: " + model.Message);

                Parallel.Invoke(() => SendEmail(toAddress, fromAddress, subject, message.ToString()));
            }
            else
            {
                ViewBag.Success = false;
                ViewBag.SubmitMessage = "There was an error sending your feedback, please try again later.";
            }
            
            return View();
        }

        // TODO: This could be in an email service configured with DI
        public void SendEmail(string to, string from, string subject, string message)
        {
            try
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(from);
                    mail.To.Add(new MailAddress(to));
                    mail.Subject = subject;
                    mail.Body = message;

                    try
                    {
                        using (var smtpClient = new SmtpClient())
                        {
                            smtpClient.Send(mail);
                        }
                    }

                    finally
                    {
                        mail.Dispose();
                    }

                }
            }
            catch(Exception ex) // TODO: Check for more specific exceptions
            {
                // Not really doing anything currently
            }
        }
    }
}