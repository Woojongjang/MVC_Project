namespace POCO
{
    public class Prerequisite
    {
        public int prereq_course { get; set; }

        public string prereq_title { get; set; }

        public int postreq_course { get; set; }

        public string postreq_title { get; set; }

        public override string ToString()
        {
            return this.prereq_course + "-" + this.prereq_title + "-" + this.postreq_course + "-" + this.postreq_title;
        }
    }
}