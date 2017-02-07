namespace POCO
{
    public class Enrollment
    {

        public string StudentId { get; set; }

        public int ScheduleId { get; set; }

        public string CourseTitle { get; set; }

        public string CourseDescription { get; set; }

        public string InstructName { get; set; }
        
        public int Year { get; set; }

        public string Quarter { get; set; }

        public string Session { get; set; }

        public string Day { get; set; }

        public string Time { get; set; }

        public string Grade { get; set; }

        public float GradeValue { get; set; }

        public override string ToString()
        {
            return this.StudentId
                + "-" + this.ScheduleId
                + "-" + this.CourseTitle 
                + "-" + this.InstructName 
                + "-" + this.Year
                + "-" + this.Quarter
                + "-" + this.Session
                + "-" + this.Day
                + "-" + this.Time
                + "-" + this.Grade 
                + "-" + this.GradeValue;
        }
    }
}
