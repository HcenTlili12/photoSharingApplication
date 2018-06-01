using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;
using PhotoSharingApp.model;
using PhotoSharingApp.Controller;
using PhotoSharingApp.Controllers;
using System.Linq;
using PhotoSharingTests.Doubles;
namespace PhotoSharingTests
{
    [TestClass]
    public class PhotoControllerTests
    {
        [TestMethod]
        public void Test_Index_Return_View()
        {
            //var controller = new PhotoController();
            var context = new FakePhotoSharingContext();
            var controller = new PhotoController(context);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void Test_PhotoGallery_Model_Type()
        {
           // var controller = new PhotoController();
           
           
            var context = new FakePhotoSharingContext();
            context.Photos = new[] { new PhotoSharingApp.model.Photo(), new PhotoSharingApp.model.Photo(), new Photo(), new Photo()}.AsQueryable();
            var controller = new PhotoController(context);
            var result = controller._PhotoGallery(3) as PartialViewResult;
            Assert.AreEqual(typeof(List<Photo>), result.Model.GetType());
        }
       
        [TestMethod]
        public void Test_GetImage_Return_Type()
        {
            // var controller = new PhotoController();
            var context = new FakePhotoSharingContext();
            context.Photos = new[] {
new PhotoSharingApp.model.Photo{ PhotoId = 1, PhotoFile = new byte[1], ImageMimeType = "image/jpeg" },
new PhotoSharingApp.model.Photo{ PhotoId = 2, PhotoFile = new byte[1], ImageMimeType = "image/jpeg" },
new PhotoSharingApp.model.Photo{ PhotoId = 3, PhotoFile = new byte[1], ImageMimeType = "image/jpeg" },
new PhotoSharingApp.model.Photo{ PhotoId = 4, PhotoFile = new byte[1], ImageMimeType = "image/jpeg" }
}.AsQueryable();
            var controller = new PhotoController(context);
            var result = controller.GetImage(1) as ActionResult;
            Assert.AreEqual(typeof( FileContentResult), result.GetType());
        }
}
}
