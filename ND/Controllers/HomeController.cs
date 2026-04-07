using Microsoft.AspNetCore.Mvc;
using ND.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace ND.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> SendEnquiry(string Name, string Email, string Mobile, string Service, string Message)
        {
            try
            {
                // Create the email content for Namastubhyam Decor
                string subject = $"New Website Enquiry: {Name}";
                string body = $@"
            <html>
                <body style='font-family: Arial, sans-serif;'>
                    <h2 style='color: #ed1c24;'>Namastubhyam Decor - New Lead</h2>
                    <hr/>
                    <p><strong>Customer Name:</strong> {Name}</p>
                    <p><strong>Email ID:</strong> {Email}</p>
                    <p><strong>Mobile Number:</strong> {Mobile}</p>
                    <p><strong>Service Requested:</strong> {Service}</p>
                    <p><strong>Requirement Details:</strong> {Message}</p>
                    <hr/>
                    <p style='font-size: 12px; color: #888;'>This email was generated from the website contact form.</p>
                </body>
            </html>";

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("divyansh1.traviyo@gmail.com", "Namastubhyam Website");
                    mail.To.Add("namstubhyamdecor05@gmail.com"); // The business email from your card
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp-relay.sendinblue.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("divyansh1.traviyo@gmail.com", "EzKdIr4k5LJ6mjxB");
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(mail);
                    }
                }

                return Json(new { success = true, message = "Your enquiry has been sent successfully!" });
            }
            catch (Exception ex)
            {
                // Log the actual error for debugging
                return Json(new { success = false, message = "Mail failure: " + ex.Message });
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
