using PhotoSharingApp.Controllers;
using PhotoSharingApp.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApp.Controller
{
    [ValueReporter]
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



        public ActionResult Index()
        {
            
            return View("Index");
           
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
     /*   [HttpPost]
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

        }  */
        
        [HttpPost]
        public ActionResult Create(Photo photo,HttpPostedFileBase image)
        {
            photo.CreatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    photo.ImageMimeType = image.ContentType;

                    photo.PhotoFile = new byte[image.ContentLength];
                    image.InputStream.Read(photo.PhotoFile, 0, image.ContentLength);
                    context.photo.Add(photo);

                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", photo);
            }
        }
        public ActionResult Display(int id)
        {
            List<Photo> photos = context.photo.ToList();
            var photoRecherche = photos.Find(photo => photo.PhotoId == id);
            if (photoRecherche != null)
                return View("Display", photoRecherche);
            else
                return HttpNotFound();
        }

        public ActionResult Delete(int id)
        {
            List<Photo> photos = context.photo.ToList();
            var photosupp = photos.Find(photo => photo.PhotoId == id);
            if (photosupp == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("Delete", photosupp);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            List<Photo> photos = context.photo.ToList();
            var photosupp = photos.Find(photo => photo.PhotoId == id);
            context.Entry(photosupp).State = EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult _PhotoGallery(int number )
        {
            List<Photo> photos = new List<Photo>();
            if (number == 0)
            {
                photos = context.photo.ToList();
            }
            else
            {
                photos = (from p in context.photo orderby p.CreatedDate ascending select p).Take(number).ToList();
            }
            return PartialView("_PhotoGallery", photos);
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
   