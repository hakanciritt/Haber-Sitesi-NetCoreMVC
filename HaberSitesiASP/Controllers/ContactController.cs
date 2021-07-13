﻿using Microsoft.AspNetCore.Mvc;
using System;
using HaberSitesiASP.Models;
using HaberSitesiASP.Helpers;
using HaberSitesiASP.Helpers.Exceptions;

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
            var message = MailSender.Mail(mail);
            MailSender.SmtpMailSendAsync(message);
            return RedirectToAction("Index", "Contact");
        }
    }
}
