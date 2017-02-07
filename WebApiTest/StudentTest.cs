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
    public class StudentTest
    {
        [TestMethod]
        public void DropCourseTest()
        {
            var studentController = new StudentController();
            studentController.DropEnrollment("A000001", 117);
            //student.ForEach(i => Console.WriteLine("{0}\t", i));
            //Console.WriteLine(student.ToString());
            //Console.WriteLine("WHAT");
            //Assert.IsNotNull(student);
            //Assert.IsTrue(student.Count > 0);
        }

        [TestMethod]
        public void AddCourseTest()
        {
            var studentController = new StudentController();
            var student = studentController.EnrollSchedule("A000001", 117);
            //student.ForEach(i => Console.WriteLine("{0}\t", i));
            //Console.WriteLine(student.ToString());
            //Console.WriteLine("WHAT");
            //Assert.IsNotNull(student);
            //Assert.IsTrue(student.Count > 0);
        }

        [TestMethod]
        public void GetEnrollmentsTest()
        {
            var studentController = new StudentController();
            var student = studentController.GetEnrollment("A000001");
            student.ForEach(i => Console.WriteLine("{0}\t", i));
            //Console.WriteLine(student.ToString());
            //Console.WriteLine("WHAT");
            Assert.IsNotNull(student);
            Assert.IsTrue(student.Count > 0);
        }

        [TestMethod]
        public void GetEnrollmentScheduleTest()
        {
            var studentController = new StudentController();
            var student = studentController.GetEnrollmentSchedule("A000001");
            student.ForEach(i => Console.WriteLine("{0}\t", i));
            //Console.WriteLine(student.ToString());
            //Console.WriteLine("WHAT");
            Assert.IsNotNull(student);
            Assert.IsTrue(student.Count > 0);
        }

        [TestMethod]
        public void GetStudentListTest()
        {
            var studentController = new StudentController();
            var student = studentController.GetStudentList();
            student.ForEach(i => Console.Write("{0}\t", i));
            //Console.WriteLine(student.ToString());
            //Console.WriteLine("WHAT");
            Assert.IsNotNull(student);
            Assert.IsTrue(student.Count > 0);
        }
    }
}
