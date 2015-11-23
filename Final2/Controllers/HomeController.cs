using Final2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Final2.Controllers
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
        public ActionResult Sent()
        {
            return View();
        }
      
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("guyver432@gmail.com"));  
                message.From = new MailAddress(model.FromEmail);  
                message.Subject = model.Subject;
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;
                using (var smtpClient = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "guyver432@gmail.com", 
                        Password = "1toolee2"  
                    };
                    smtpClient.Credentials = credential;   //was getting error fixed with
                    smtpClient.Host = "smtp.gmail.com";   //security settings at the followig link https://www.google.com/settings/security/lesssecureapps and enable less secure apps
                    smtpClient.Port = 587; 
                    smtpClient.EnableSsl = true;
                    await smtpClient.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public JsonResult GetData()
        {
            EmailFormModel efm = new EmailFormModel();
            efm.FromName = "MVC Site";
            efm.FromEmail = "guvyer432@gmail.com";
            efm.Subject = "From Server";
            return Json(efm, JsonRequestBehavior.AllowGet);
        }
    }
}