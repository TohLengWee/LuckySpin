﻿using System.Web.Mvc;
using LuckySpin.Models.Register;

namespace LuckySpin.Controllers
{
    public class RegisterController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(Registration registration)
        {
            return RedirectToAction("Index", "Home");
        }
    }

    public enum Bank
    {
        BCA,
        MANDIRI,
        BRI,
        BNI,
        CIMB
    }
}