﻿namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface IScheduleRepository
    {
        List<Schedule> GetScheduleList(string year, string quarter, ref List<string> errors);

        float GetScheduleCapeAverage(int scheduleID, ref List<string> errors);
    }
}
