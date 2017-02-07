namespace Service
{
    using System.Collections.Generic;
    using IRepository;
    using POCO;
    using System;
    using System.Text.RegularExpressions;
    public class CourseService
    {
        private readonly ICourseRepository repository;

        public CourseService(ICourseRepository repository)
        {
            this.repository = repository;
        }

        public List<Course> GetCourseList(ref List<string> errors)
        {
            return this.repository.GetCourseList(ref errors);
        }

        public void InsertPrerequisite(ref List<string> errors, int course_id, int prereq_id)
        {
            if(course_id < 0)
            {
                errors.Add("Invalid post course id");
                throw new ArgumentException();
            }
            if(prereq_id < 0 )
            {
                errors.Add("Invalid pre course id");
                throw new ArgumentException();
            }
            this.repository.InsertPrerequisite(ref errors, course_id, prereq_id);
        }

        public List<Prerequisite> GetPrerequisite(ref List<string> errors)
        {
            return this.repository.GetPrerequisite(ref errors);
        }

        public int InsertCourse(ref List<string> errors, int course_id, string title, string level, string description)
        {
            //@"^[a-zA-Z0-9\_]+$"
            // Create the regular expression
            string titlepattern = @"^[a-zA-Z0-9\s]+$";
            Regex titleregex = new Regex(titlepattern);
            
            // Compare a string against the regular expression
            if(!titleregex.IsMatch(title))
            {
                errors.Add("Invalid course title");
                throw new ArgumentException();
            }

            string levelpattern = @"^[a-zA-Z]+$";
            Regex levelregex = new Regex(levelpattern);

            if (!levelregex.IsMatch(level))
            {
                errors.Add("Invalid course level");
                throw new ArgumentException();
            }

            if (course_id < 0)
            {
                errors.Add("Invalid pre course id");
                throw new ArgumentException();
            }

            return this.repository.InsertCourse(ref errors, course_id, title, level, description);
        }

        public int DeleteCourse(ref List<string> errors, int course_id, string title)
        {
            return this.repository.DeleteCourse(ref errors, course_id, title);
        }

        public void DeletePrerequisite(ref List<string> errors, int course_id, int prereq_id)
        {
            this.repository.DeletePrerequisite(ref errors, course_id, prereq_id);
        }

        public int UpdateCourse(ref List<string> errors, int course_id, string title, string level, string description)
        {
            return this.repository.UpdateCourse(ref errors, course_id, title, level, description);
        }

        public void UpdatePrerequisite(ref List<string> errors, int course_id, int prereq_id)
        {
            this.repository.UpdatePrerequisite(ref errors, course_id, prereq_id);
        }
    }
}
