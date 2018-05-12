using PhotoSharingApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApp.Controller
{
    public class PhotoController : System.Web.Mvc.Controller
    {
        // GET: photo
        public ActionResult Index()
        {
            PhotoSharingContext context =new PhotoSharingContext();
            Photo p = context.photo.First<Photo>();
            var photo = new Photo();
            return View(p);
        }
    }
}