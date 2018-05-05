using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApp.Controller
{
    public class photo : System.Web.Mvc.Controller
    {
        // GET: photo
        public ActionResult Index()
        {
            return View();
        }
    }
}