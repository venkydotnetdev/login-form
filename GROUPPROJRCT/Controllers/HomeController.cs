using GROUPPROJRCT.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GROUPPROJRCT.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(ModelClass venky)
        {
            if (ModelState.IsValid)
            {
                Repository obj = new Repository();
                obj.AddUser(venky);
                return RedirectToAction("GetAllUsers");
            }
            return View();
        }

        
        public ActionResult GetAllUsers()
        {
            Repository obj = new Repository();
            ModelState.Clear();
            return View(obj.GetAllUsers());
        }
        

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationModel venky)
        {
            if (ModelState.IsValid)
            {
                Repository obj = new Repository();
                obj.Registration(venky);
                return RedirectToAction("GetAllUserRequests");
            }
            return View();
        }
        public ActionResult GetAllUserRequests()
        {
            Repository obj = new Repository();
            ModelState.Clear();
            return View(obj.GetAllUserRequests());
        }

    }
}