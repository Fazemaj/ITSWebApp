﻿using ITS_Web.Configuration;
using ITS_Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace ITS_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;

        string name = "";
        string email = "";
        string phone = "";

        List<string> myList = new List<string>();

        public HomeController(ILogger<HomeController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            ViewBag.ShowTopBar = true;
            return View();
        }

        [HttpPost]
        public IActionResult SendEmailFromForl(JobApply data)
        {
            if (ModelState.IsValid)
            {
                var response = _emailService.SendEmailAsync(data);

                ViewBag.ShowTopBar = true;

                //Layout layout = new Layout
                //{
                //    IsSucces = response
                //};
                //this.ViewData["Layout"] = layout;

                TempData["response"] = response;

                return RedirectToAction("Career");
            }
            return RedirectToAction("Career");
        }

        [HttpPost]
        public IActionResult SendEmail(JobApply data)
        {
            var response = _emailService.SendEmailAsync(data);

            ViewBag.ShowTopBar = true;

            return Json(response);
        }

        [HttpPost]
        public IActionResult ContactEmail(Contact data)
        {
            if (ModelState.IsValid)
            {
                var response = _emailService.ContactEmailAsync(data);

                ViewBag.ShowTopBar = true;

                TempData["response"] = response;

                return RedirectToAction("Contact");

            }
            return RedirectToAction("Contact");
        }

        public IActionResult Itoutsourcing()
        {
            // ViewBag.ShowTopBar = false;
            ViewBag.ShowTopBar = true;
            return View();
        }

        [HttpGet]
        public IActionResult About()
        {
            ViewBag.ShowTopBar = true;
            return View();
        }

        [HttpGet]
        [Route("Career")]
        public IActionResult Career()
        {
            ViewBag.ShowTopBar = true;

            try
            {
                bool? response = (bool)TempData["response"];
                var layout = new Layout
                {
                    IsSucces = response
                };
                this.ViewData["Layout"] = layout;
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("Contact")]
        public IActionResult Contact()
        {
            ViewBag.ShowTopBar = true;

            try
            {
                bool? response = (bool)TempData["response"];
                var layout = new Layout
                {
                    IsSucces = response
                };
                this.ViewData["Layout"] = layout;
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("/Services/ManagementConsulting​")]
        public IActionResult MC()
        {
            ViewBag.ShowTopBar = true;
            return View();
        }

        [HttpGet]
        [Route("/Services/BC")]
        public IActionResult BC()
        {

            ViewBag.ShowTopBar = true;
            return View();
        }

        //[HttpPost]
        //[Route("/AddContact")]
        //public IActionResult AddContact(EmailData email)
        //{
        //    ViewBag.ShowTopBar = true;
        //    try
        //    {
        //        var response = _emailService.SendEmail(email);
        //        return Redirect("Contact");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
