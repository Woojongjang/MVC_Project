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

    public class ScheduleController : ApiController
    {
        [HttpGet]
        public float GetScheduleCapeAverage(int scheduleID)
        {
            var errors = new List<string>();
            var repository = new ScheduleRepository();
            var service = new ScheduleService(repository);
            return service.GetScheduleCapeAverage(scheduleID, ref errors);
        }

    }
}