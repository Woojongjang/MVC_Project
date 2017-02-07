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
    public class CourseTest
    {
        [TestMethod]
        public void UpdatePrerequisiteTest()
        {
            var courseController = new CourseController();
            courseController.UpdatePrerequisite(1, 3);
            //course.ForEach(i => Console.WriteLine("{0}\t", i));
            //Console.WriteLine(student.ToString());
            //Console.WriteLine("WHAT");
            //Assert.IsNotNull(course);
            //Assert.IsTrue(course.Count > 0);
        }
        [TestMethod]
        public void DeletePrerequisiteTest()
        {
            var courseController = new CourseController();
            var result = courseController.DeletePrerequisite(2, 1);
            //course.ForEach(i => Console.WriteLine("{0}\t", i));
            //Console.WriteLine(student.ToString());
            //Console.WriteLine("WHAT");
            //Assert.IsNotNull(course);
            Assert.IsTrue(result == "ok");
        }

        [TestMethod]
        public void GetAllPrerequisitesTest()
        {
            var courseController = new CourseController();
            var course = courseController.GetPrerequisite();
            course.ForEach(i => Console.WriteLine("{0}\t", i));
            //Console.WriteLine(student.ToString());
            //Console.WriteLine("WHAT");
            Assert.IsNotNull(course);
            Assert.IsTrue(course.Count > 0);
        }

        [TestMethod]
        public void InsertPrereqAPITest()
        {
            var courseController = new CourseController();
            var course = courseController.InsertPrerequisite(2, 1);
            Assert.IsTrue(course == "ok");
        }

        [TestMethod]
        public void DeletePrereqAPITest()
        {
            var courseController = new CourseController();
            var course = courseController.DeletePrerequisite(1, 2);
            Assert.AreEqual(course, 1);
        }
        /*
        [TestMethod]
        public void UpdatePrereqAPITest()
        {
            var courseController = new CourseController();
            var course = courseController.UpdatePrerequisite(1, 1);
            Assert.AreEqual(course, 1);
        }*/

        [TestMethod]
        public void InsertCourseAPITest()
        {
            var courseController = new CourseController();
            var course = courseController.InsertCourse(1, "class123", "ugrad", "blahblah");
            Assert.AreEqual(course, 1);
        }

        /*[TestMethod]
        public void UpdateCourseAPITest()
        {
            var courseController = new CourseController();
            var course = courseController.UpdateCourse(1, "class123", "grad", "No");
            Assert.AreEqual(course, 1);
        }

        /*[TestMethod]
        public void DeleteCourseAPITest()
        {
            var courseController = new CourseController();
            var course = courseController.DeleteCourse(1, "class123");
            Assert.AreEqual(course, 1);
        }*/
    }
}
