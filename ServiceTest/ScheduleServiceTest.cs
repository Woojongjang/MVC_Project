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
    public class ScheduleServiceTest
    {
        [TestMethod]
        public void GetScheduleCapeAverageTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            var avg = scheduleService.GetScheduleCapeAverage(0, ref errors);
            
            //// Assert
            Assert.IsInstanceOfType(avg, typeof(float));
        }

        [TestMethod]
        public void GetScheduleCapeAverageGreaterThanNegative()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            var avg = scheduleService.GetScheduleCapeAverage(0, ref errors);

            //// Assert
            Assert.IsTrue(avg > -1);
        }

        [TestMethod]
        public void GetScheduleCapeAverageLessThanEqualTen()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            var avg = scheduleService.GetScheduleCapeAverage(0, ref errors);

            //// Assert
            Assert.IsTrue(avg <= 10);
        }

        [TestMethod]
        public void GetScheduleCapeAverageIsFloat()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            var avg = scheduleService.GetScheduleCapeAverage(0, ref errors);

            //// Assert
            Assert.IsInstanceOfType(avg, typeof(float));
        }

        [TestMethod]
        public void GetScheduleCapeAverageIsNotNull()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            var avg = scheduleService.GetScheduleCapeAverage(0, ref errors);

            //// Assert
            Assert.IsNotNull(avg);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetScheduleCapeAverageScheduleIDNotNegative()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<IScheduleRepository>();
            var scheduleService = new ScheduleService(mockRepository.Object);

            //// Act
            var avg = scheduleService.GetScheduleCapeAverage(-1, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }
    }
}
