using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;

    public class CapeService
    {
        private readonly ICapeRepository repository;

        public CapeService(ICapeRepository repository)
        {
            this.repository = repository;
        }

        public List<Cape> GetCapeRating(string stud_id, ref List<string> errors)
        {
            return this.repository.GetCapeStudent(stud_id, ref errors);

        }

        public void UpdateCapeRating(string stud_id, int instr_id, int sched_id, int rating, ref List<string> errors)
        {

            if (instr_id < 0)
            {
                errors.Add("instr_id cannot be negative");
                ////throw new ArgumentException();
            }

            if (sched_id < 0)
            {
                errors.Add("sched_id cannot be negative");
                ////throw new ArgumentException();
            }

            if (rating < 0)
            {
                errors.Add("rating cannot be less than 0");
                ////throw new ArgumentException();
            }

            if (rating > 10)
            {
                errors.Add("rating cannot be greater than 10");
                ////throw new ArgumentException();
            }

            this.repository.UpdateCapeRating(stud_id, instr_id, sched_id, rating, ref errors);
        }

        public void DeleteCapeRating(string stud_id, int instr_id, int sched_id, ref List<string> errors)
        {

            if (instr_id < 0)
            {
                errors.Add("instr_id cannot be negative");
                //throw new ArgumentException();
            }

            if (sched_id < 0)
            {
                errors.Add("sched_id cannot be negative");
                //throw new ArgumentException();
            }

            this.repository.DeleteCapeRating(stud_id, instr_id, sched_id, ref errors);
        }

        public void InsertCapeRating(string stud_id, int instr_id, int sched_id, int rating, ref List<string> errors)
        {

            if (instr_id < 0)
            {
                errors.Add("instr_id cannot be negative");
                ////throw new ArgumentException();
            }

            if (sched_id < 0)
            {
                errors.Add("sched_id cannot be negative");
                ////throw new ArgumentException();
            }

            if (rating < 0)
            {
                errors.Add("rating cannot be less than 0");
                ////throw new ArgumentException();
            }

            if (rating > 10)
            {
                errors.Add("rating cannot be greater than 10");
                //////throw new ArgumentException();
            }

            this.repository.InsertCapeRating(stud_id, instr_id, sched_id, rating, ref errors);
        }

        public List<Cape> GetCapeStudent(string stud_id, ref List<string> errors)
        {

            return this.repository.GetCapeStudent(stud_id, ref errors);
        }

        public List<Cape> GetCapeInstructor(int instr_id, ref List<string> errors)
        {
            if (instr_id < 0)
            {
                errors.Add("instr_id cannot be negative");
                //throw new ArgumentException();
            }

            return this.repository.GetCapeInstructor(instr_id, ref errors);
        }
    }
}
