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
        public ActionResult First()
        {
            PhotoSharingContext context = new PhotoSharingContext();
            Photo firstPhoto = context.photo.ToList()[0];
            if (firstPhoto != null)
            {
                return View("Details", firstPhoto);
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult Create()
        {
            Photo newPhoto = new Photo();
            return View("Create", newPhoto);
}
    }

   
    /* public class PhotoController : System.Web.Mvc.Controller
     {

         public ActionResult Index()
         {
             List<Photo> a = new List<Photo>();
             PhotoSharingContext context = new PhotoSharingContext();
             a = context.photo.ToList<Photo>();
             return View("Index",a);
         }
     }  */
}