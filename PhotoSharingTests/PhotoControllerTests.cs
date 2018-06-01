using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;
using PhotoSharingApp.model;
using PhotoSharingApp.Controller;
using PhotoSharingApp.Controllers;

namespace PhotoSharingTests
{
    [TestClass]
    public class PhotoControllerTests
    {
        [TestMethod]
        public void Test_Index_Return_View()
        {
            var controller = new PhotoController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void Test_PhotoGallery_Model_Type()
        {
            var controller = new PhotoController();
            var result = controller._PhotoGallery(3) as PartialViewResult;
            Assert.AreEqual(typeof(List<Photo>), result.Model.GetType());
        }
       
        [TestMethod]
        public void Test_GetImage_Return_Type()
        {
            var controller = new PhotoController();
            var result = controller.GetImage(3) as ActionResult;
            Assert.AreEqual(typeof( FileContentResult), result.GetType());
        }
}
}
