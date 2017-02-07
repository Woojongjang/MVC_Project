namespace Service
{
    using System.Collections.Generic;
    using System;
    using IRepository;

    using POCO;

    public class ScheduleService
    {
        private readonly IScheduleRepository repository;

        public ScheduleService(IScheduleRepository repository)
        {
            this.repository = repository;
        }

        public List<Schedule> GetScheduleList(string year, string quarter, ref List<string> errors)
        {
            return this.repository.GetScheduleList(year, quarter, ref errors);
        }

        public float GetScheduleCapeAverage(int scheduleID, ref List<string> errors)
        {
            if (scheduleID < 0)
            {
                errors.Add("Invalid schedule id");
                throw new ArgumentException();
            }

            return this.repository.GetScheduleCapeAverage(scheduleID, ref errors);
        }

    }
}
