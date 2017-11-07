using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iHeartMediaDemo;
using iHeartMediaDemo.Controllers;
using iHeartMediaDemo.Models;

namespace iHeartMediaDemo.Tests.Controllers
{
    [TestClass]
    public class StationControllerTest
    {
        [TestMethod]
        public void GetAll()
        {
            // Arrange
            StationController controller = new StationController();

            // Act
            List<Station> result = controller.GetAll();
            Station toTest = result.FirstOrDefault();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(toTest.Id, 1);
            Assert.AreEqual(toTest.Name, "The Beat");
            Assert.AreEqual(toTest.CallSign, "102.3");
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            StationController controller = new StationController();

            // Act
            Station toTest = controller.GetById(1);

            // Assert
            Assert.AreEqual(toTest.Id, 1);
            Assert.AreEqual(toTest.Name, "The Beat");
            Assert.AreEqual(toTest.HdEnabled, true);
            Assert.AreEqual(toTest.CallSign, "102.3");
        }

        [TestMethod]
        public void GetByName()
        {
            // Arrange
            StationController controller = new StationController();

            // Act
            Station toTest = controller.GetByName("The Beat");

            // Assert
            Assert.AreEqual(toTest.Id, 1);
            Assert.AreEqual(toTest.Name, "The Beat");
            Assert.AreEqual(toTest.CallSign, "102.3");
        }

        [TestMethod]
        public void getHdEnabled()
        {
            // Arrange
            StationController controller = new StationController();

            // Act
            List<Station> result = controller.GetByHdEnabled(true);
            Station toTest = result.FirstOrDefault();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(toTest.Id, 1);
            Assert.AreEqual(toTest.Name, "The Beat");
            Assert.AreEqual(toTest.CallSign, "102.3");
        }

        [TestMethod]
        public void AddStation()
        {
            // Arrange
            StationController controller = new StationController();
            Station toAdd = new Station
            {
                Id = 5,
                Name = "The Zone",
                HdEnabled = true,
                CallSign = "1300"
            };

            // Act
            HttpResponseMessage result = controller.AddStation(toAdd);

            // Assert
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "This station already exists")]
        public void AddStationWithException()
        {
            // Arrange
            StationController controller = new StationController();
            Station toAdd = new Station
            {
                Id = 5,
                Name = "The Zone",
                HdEnabled = true,
                CallSign = "1300"
            };

            // Act
            HttpResponseMessage result = controller.AddStation(toAdd);

            // Assert
            // There is no Assert since the ExpectedException acts as the Assert
        }

        [TestMethod]
        public void DeleteStation()
        {
            // Arrange
            StationController controller = new StationController();

            // Act
            HttpResponseMessage result = controller.DeleteStation(5);

            // Assert
            Assert.IsTrue(result.IsSuccessStatusCode);
        }        
    }
}
