using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTest
{
    using System;
    using System.Collections.Generic;

    using IRepository;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using POCO;
    using Service;
    
    [TestClass]
    public class CourseServiceTest
    {
        /*[TestMethod]
        public void InsertPrerequisiteTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            int returnVal = courseService.InsertPrerequisite(ref errors, 1, 1);

            //// Assert
            Assert.AreEqual(returnVal, 1);
        }*/
        /*
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertPrerequisitePreCourseIdNotNegative()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.InsertPrerequisite(ref errors, 1, -1);

            //// Assert
            Assert.AreEqual(errors.Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertPrerequisitePostCourseIdNotNegative()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            courseService.InsertPrerequisite(ref errors, -1, 1);

            //// Assert
            Assert.AreEqual(errors.Count, 1);
        }/**/

        [TestMethod]
        public void GetPrerequisiteCourseIdNotNegative()
        {
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            var returnVal = courseService.GetPrerequisite(ref errors);

            //// Assert
            Assert.AreEqual(errors.Count, 1);
        }

        /*[TestMethod]
        public void InsertCourseRunTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            var returnVal = courseService.InsertCourse(ref errors, 1, "blah", "blah2", "blahblah");

            //// Assert
            Assert.AreEqual(returnVal, 1);
        }*/

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertCourseNameRegex()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            var returnVal = courseService.InsertCourse(ref errors, 1, "blah#%^$", "blah2", "blahblah");

            //// Assert
            Assert.AreEqual(errors.Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertCourseLevelRegex()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ICourseRepository>();
            var courseService = new CourseService(mockRepository.Object);

            //// Act
            var returnVal = courseService.InsertCourse(ref errors, 1, "blah", "blah^$#!%", "blahblah");

            //// Assert
            Assert.AreEqual(errors.Count, 1);
        }
    }
}
