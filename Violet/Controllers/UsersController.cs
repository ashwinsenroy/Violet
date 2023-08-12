using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Violet.Interfaces.ManagerInterfaces;
using Violet.Models;

namespace Violet.Controllers
{
    public class UsersController : Controller
    {
        public IUsersManager objUsersManager;

        public UsersController(IUsersManager usersManager)
        {
            objUsersManager = usersManager;
        }
        // GET: Users
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Users objUser)
        {
            objUsersManager.AddNewUser(objUser);
            return View();
        }

        

    }
}