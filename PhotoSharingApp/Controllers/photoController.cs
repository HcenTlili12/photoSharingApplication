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
        private PhotoSharingContext context = new PhotoSharingContext();
        // GET: photo
     /*   public ActionResult Index()
        {
            
            Photo p = context.photo.First<Photo>();
            var photo = new Photo();
            return View(p);
        }  */

       
            
          //  [SimpleActionFilter]
            public ActionResult Index()
            {
                return View("Index", context.photo.ToList<Photo>());
            }
        
        public ActionResult GetPhotoByTitle(string title)
        {
           
            var query = from p in context.photo
                        where p.Title == title
                        select p;
            Photo requestedPhoto = (Photo)query.FirstOrDefault();
            if (requestedPhoto != null)
            {
                return View("details", requestedPhoto);
            }
            else
            {
                return HttpNotFound();
            }
        }
        public FileContentResult GetImage(int id)
        {
            List<Photo> photos = context.photo.ToList();
            var verif = photos.Find(photo => photo.PhotoId == id);
            if (verif != null)
            {

                return (new FileContentResult(verif.PhotoFile, verif.ImageMimeType));
            }
            else
            {
                return null;
            }
        }
        public ActionResult details()
        {
          
            Photo firstPhoto = context.photo.ToList()[0];
            if (firstPhoto != null)
            {
                return View("details", firstPhoto);
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
        [HttpPost]
        public ActionResult Create(Photo photo)
        {
            
            if (ModelState.IsValid)
            {
                context.photo.Add(photo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", photo);
            }

        }
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
   