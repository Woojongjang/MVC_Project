namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface ICourseRepository
    {
        List<Course> GetCourseList(ref List<string> errors);

        List<Prerequisite> GetPrerequisite(ref List<string> errors);

        void InsertPrerequisite(ref List<string> errors, int course_id, int prereq_id);

        int InsertCourse(ref List<string> errors, int course_id, string title, string level, string description);

        int DeleteCourse(ref List<string> errors, int course_id, string title);

        void DeletePrerequisite(ref List<string> errors, int course_id, int prereq_id);

        int UpdateCourse(ref List<string> errors, int course_id, string title, string level, string description);

        void UpdatePrerequisite(ref List<string> errors, int course_id, int prereq_id);

        /*int UpdateCapeRating(ref List<string> errors, string stud_id, int instr_id, int sched_id, int rating);

        int DeleteCapeRating(ref List<string> errors, string stud_id, int instr_id, int sched_id);

        int InsertCapeRating(ref List<string> errors, string stud_id, int instr_id, int sched_id, int rating);

        int GetCapeRating(ref List<string> errors, string stud_id, int instr_id, int sched_id);*/
    }
}
