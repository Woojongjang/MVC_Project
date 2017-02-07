using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Cape
    {
        public string studentID { get; set; }

        public int instructorID { get; set; }

        public int ScheduleId { get; set; }

        public int CapeRating { get; set; }

        public override string ToString()
        {
            return this.studentID + "-" + this.instructorID + "-" + this.ScheduleId + "-" + this.CapeRating;
        }
    }
}
