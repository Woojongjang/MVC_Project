using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using POCO;
    using WebApi.Controllers;

    [TestClass]
    public class CapeTest
    {
        [TestMethod]
        public void GetCapeRatingAPITest()
        {
            var capeController = new CapeController();
            var cape = capeController.GetCapeRating("A000001");


            cape.ForEach(i => Console.WriteLine("{0}\t", i));
            //Console.WriteLine(student.ToString());
            //Console.WriteLine("WHAT");
            Assert.IsNotNull(cape);
            Assert.IsTrue(cape.Count > 0);
        }

        [TestMethod]
        public void InsertCapeRatingAPITest()
        {
            var capeController = new CapeController();
            var cape = capeController.InsertCapeRating("A000001", 1, 1, 5);
            Assert.AreEqual("ok", cape);
        }

        [TestMethod]
        public void InsertCapeRatingAPIErrorTest()
        {
            var capeController = new CapeController();
            var cape = capeController.InsertCapeRating("A000001", 1, 1, 15);
            Assert.AreEqual("error", cape);
        }

        [TestMethod]
        public void UpdateCapeRatingAPITest()
        {
            var capeController = new CapeController();
            var cape = capeController.UpdateCapeRating("A000001", 1, 1, 1);
            Assert.AreEqual("ok", cape);
        }

        [TestMethod]
        public void UpdateCapeRatingAPIErrorTest()
        {
            var capeController = new CapeController();
            var cape = capeController.UpdateCapeRating("A000001", 1, 1, 15);
            Assert.AreEqual("error", cape);
        }

        [TestMethod]
        public void DeleteCapeRatingAPITest()
        {
            var capeController = new CapeController();
            var cape = capeController.DeleteCapeRating("A000001", 1, 1);
            Assert.AreEqual("ok", cape);
        }
    }
}
