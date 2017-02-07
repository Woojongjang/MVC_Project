namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface ICapeRepository
    {
        void UpdateCapeRating(string stud_id, int instr_id, int sched_id, int rating, ref List<string> errors);

        int GetCapeRating(string stud_id, int instr_id, int sched_id, ref List<string> errors);

        void DeleteCapeRating(string stud_id, int instr_id, int sched_id, ref List<string> errors);

        void InsertCapeRating(string stud_id, int instr_id, int sched_id, int rating, ref List<string> errors);

        List<Cape> GetCapeStudent(string stud_id, ref List<string> errors);

        List<Cape> GetCapeInstructor(int instr_id, ref List<string> errors);
    }
}
