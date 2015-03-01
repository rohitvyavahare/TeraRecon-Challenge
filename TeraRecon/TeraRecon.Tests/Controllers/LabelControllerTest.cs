using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeraRecon;
using TeraRecon.Controllers;
using TeraRecon.Models;


namespace TeraRecon.Tests.Controllers
{
    [TestClass]
    public class LabelControllerTest
    {
        

        [TestMethod]
        public void Index()
        {
            // Arrange
            LabelController controller = new LabelController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Search()
        {
            // Arrange
            LabelController controller = new LabelController();

            // Act
            ViewResult result = controller.Search("rohit") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AutoComeplete()
        {
            // Arrange
            LabelController controller = new LabelController();

            // Act
            JsonResult result = controller.AutoComplete("rohit") as JsonResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Create()
        {
            // Arrange
            LabelController controller = new LabelController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit()
        {
           
            // Arrange
            LabelController controller = new LabelController();
            
            // Act
            ViewResult result = controller.Edit(1) as ViewResult;

            // Assert            
            Assert.IsNotNull(result.ViewData.Model);

            Labels label = new Labels();
            label.Id = 99;
            label.item = "rohit";
            label.label = "vyavahare";

            controller.Create(label);
            // Act
            var result2 = (RedirectToRouteResult)controller.Edit(label);
            result2.RouteValues["action"].Equals("Index");         
            Assert.AreEqual("Index", result2.RouteValues["action"]);
         
        
            // Assert
            Assert.IsNotNull(result);


        }

        [TestMethod]
        public void Delete()
        {

            // Arrange
            LabelController controller = new LabelController();

            // Act
            ViewResult result = controller.Delete(1) as ViewResult;

            // Assert            
            Assert.IsNotNull(result.ViewData.Model);

            
        }
    }
}
