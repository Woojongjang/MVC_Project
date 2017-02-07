namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;

    public class CourseController : ApiController
    {
        [HttpGet]
        public List<Course> GetCourseList()
        {
            var service = new CourseService(new CourseRepository());
            var errors = new List<string>();

            //// we could log the errors here if there are any...
            return service.GetCourseList(ref errors);
        }

        [HttpGet]
        public List<Prerequisite> GetPrerequisite()
        {
            var service = new CourseService(new CourseRepository());
            var errors = new List<string>();

            //// we could log the errors here if there are any...
            return service.GetPrerequisite(ref errors);
        }

        [HttpPost]
        public string InsertPrerequisite(int course_id, int prereq_id)
        {
            var service = new CourseService(new CourseRepository());
            var errors = new List<string>();

            //// we could log the errors here if there are any...
            service.InsertPrerequisite(ref errors, course_id, prereq_id);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string UpdatePrerequisite(int course_id, int prereq_id)
        {
            var service = new CourseService(new CourseRepository());
            var errors = new List<string>();

            //// we could log the errors here if there are any...
            service.UpdatePrerequisite(ref errors, course_id, prereq_id);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public string DeletePrerequisite(int course_id, int prereq_id)
        {
            var service = new CourseService(new CourseRepository());
            var errors = new List<string>();

            //// we could log the errors here if there are any...
            service.DeletePrerequisite(ref errors, course_id, prereq_id);

            if (errors.Count == 0)
            {
                return "ok";
            }

            return "error";
        }

        [HttpPost]
        public int InsertCourse(int course_id, string title, string level, string description)
        {
            var service = new CourseService(new CourseRepository());
            var errors = new List<string>();

            //// we could log the errors here if there are any...
            return service.InsertCourse(ref errors, course_id, title, level, description);
        }

        [HttpPut]
        public int UpdateCourse(int course_id, string title, string level, string description)
        {
            var service = new CourseService(new CourseRepository());
            var errors = new List<string>();

            //// we could log the errors here if there are any...
            return service.UpdateCourse(ref errors, course_id, title, level, description);
        }

        [HttpDelete]
        public int DeleteCourse(int course_id, string title)
        {
            var service = new CourseService(new CourseRepository());
            var errors = new List<string>();

            //// we could log the errors here if there are any...
            return service.DeleteCourse(ref errors, course_id, title);
        }
    }
}