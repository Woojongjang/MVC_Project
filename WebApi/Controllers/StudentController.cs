namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;
    public class StudentController : ApiController
    {
        [HttpGet]
        public List<Student> GetStudentList()
        {
            var errors = new List<string>();
            var repository = new StudentRepository();
            var service = new StudentService(repository);
            return service.GetStudentList(ref errors);
        }

        [HttpGet]
        public List<Enrollment> GetEnrollmentSchedule(string id)
        {
            var errors = new List<string>();
            var studentRepository = new StudentRepository();
            var courseRepository = new CourseRepository();
            
            //var courseService = new CourseService(courseRepository);
            var studentService = new StudentService(studentRepository);
            //List<Prerequisite> studentPrereq = courseService.GetPrerequisite(ref errors, 0);

            //return studentService.GetEnrollmentSchedule(id, studentPrereq, ref errors);
            return studentService.GetEnrollmentSchedule(id, ref errors);
        }

        [HttpPost]
        public string EnrollSchedule(string id, int scheduleId)
        {
            var errors = new List<string>();
            var repository = new StudentRepository();
            var service = new StudentService(repository);

            service.EnrollSchedule(id, scheduleId, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DropEnrollment(string id, int scheduleId)
        {
            var errors = new List<string>();
            var repository = new StudentRepository();
            var service = new StudentService(repository);

            service.DropEnrolledSchedule(id, scheduleId, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpGet]
        public List<Enrollment> GetEnrollment(string id)
        {
            var errors = new List<string>();
            var repository = new StudentRepository();
            var service = new StudentService(repository);
            return service.GetEnrollments(id, ref errors);
        }

        [HttpGet]
        public Student GetStudent(string id)
        {
            var errors = new List<string>();
            var repository = new StudentRepository();
            var service = new StudentService(repository);
            return service.GetStudent(id, ref errors);
        }

        [HttpPost]
        public string InsertStudent(Student student)
        {
            var errors = new List<string>();
            var repository = new StudentRepository();
            var service = new StudentService(repository);
            service.InsertStudent(student, ref errors);
            if (errors.Count == 0)
            {
                return "ok";
            }
            
            return "error";
        }

        [HttpPost]
        public string UpdateStudent(Student student)
        {
            var errors = new List<string>();
            var repository = new StudentRepository();
            var service = new StudentService(repository);
            service.UpdateStudent(student, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeleteStudent(string id)
        {
            var errors = new List<string>();
            var repository = new StudentRepository();
            var service = new StudentService(repository);
            service.DeleteStudent(id, ref errors);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeleteStudentAsync(string id)
        {
            var student = new Bus136.Contract.Student
                              {                                  
                                  Id = id,
                                  Command = "Delete"
                              };

            NserviceBus.NserviceBusClient.Bus.Send(student);
            return "Sent delete student message to MSMQ using NServiceBus";
        }
    }
}