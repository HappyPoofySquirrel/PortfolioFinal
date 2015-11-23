using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final2.Models;

namespace Final2.Controllers
{
    public class MainsController : Controller
    {
        private Final2Entities db = new Final2Entities();

        // GET: Mains
        public ActionResult Index()
        {
            return View(db.Mains.ToList());
        }
    }
}
