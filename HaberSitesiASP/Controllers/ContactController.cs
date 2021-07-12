using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using HaberSitesiASP.Models;
using MimeKit.Text;
using HaberSitesiASP.Helpers;

namespace HaberSitesiASP.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Mail mail)
        {
            var message = MailSettings.Mail(mail);
            MailSettings.SmtpMailSendAsync(message);
            return RedirectToAction("Index", "Contact");
        }
    }
}
