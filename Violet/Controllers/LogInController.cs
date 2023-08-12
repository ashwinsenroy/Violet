using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Violet.Controllers
{
    public class LogInController : Controller
    {
        [HttpGet]
        public ActionResult LogIn()
        {


            return View();
        }

        //[HttpGet]
        //public ActionResult LogIn()
        //{


        //    return View();
        //}
    }
}