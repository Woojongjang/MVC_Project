namespace POCO
{
    public class Schedule
    {
        public int ScheduleId { get; set; }

        public Instructor Instructor { get; set; }

        public string Year { get; set; }

        public string Quarter { get; set; }

        public string Session { get; set; }

        public Course Course { get; set; }

        public int CourseId { get; set; }

        public override string ToString()
        {
            return this.ScheduleId + "-" + this.Year + "-" + this.Quarter + "-" + this.Session + "-" + this.Course + "-" + this.CourseId + "-" + this.Instructor;
        }
    }
}
