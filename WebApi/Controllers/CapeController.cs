using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using POCO;
    using Repository;
    using Service;

    public class CapeController : ApiController
    {
        [HttpGet]
        public List<Cape> GetCapeRating(string stud_id)
        {
            var errors = new List<string>();
            var repository = new CapeRepository();
            var service = new CapeService(repository);
            return service.GetCapeRating(stud_id, ref errors);
        }

        [HttpPost]
        public string InsertCapeRating(string stud_id, int instr_id, int sched_id, int rating)
        {
            var errors = new List<string>();
            var repository = new CapeRepository();
            var service = new CapeService(repository);
            service.InsertCapeRating(stud_id, instr_id, sched_id, rating, ref errors);

            if(errors.Count > 0)
            {
                return "error";
            }
            else
            {
                return "ok";
            }
        }

        [HttpDelete]
        public string DeleteCapeRating(string stud_id, int instr_id, int sched_id)
        {
            var errors = new List<string>();
            var repository = new CapeRepository();
            var service = new CapeService(repository);
            service.DeleteCapeRating(stud_id, instr_id, sched_id, ref errors);

            if (errors.Count > 0)
            {
                return "error";
            }
            else
            {
                return "ok";
            }
        }

        [HttpPut]
        public string UpdateCapeRating(string stud_id, int instr_id, int sched_id, int rating)
        {
            var errors = new List<string>();
            var repository = new CapeRepository();
            var service = new CapeService(repository);
            service.UpdateCapeRating(stud_id, instr_id, sched_id, rating, ref errors);

            if (errors.Count > 0)
            {
                return "error";
            }
            else
            {
                return "ok";
            }
        }
    }
}