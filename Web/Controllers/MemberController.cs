﻿using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
