using System;
using System.Collections.Generic;

namespace Tms.Services.EdgeManagement.Domain
{
    public class Schedule
    {
        public Schedule(DateTime validFrom, DateTime? validTo = null)
        {
            ValidFrom = validFrom;
            ValidTo = validTo;            
        }

        public DateTime ValidFrom { get; private set; }

        public DateTime? ValidTo { get; private set; }
    }

    public class WeeklySchedule : Schedule
    {
        public WeeklySchedule(DateTime validFrom, DayOfWeek[] weekdays, DateTime? validTo = null)
            : base(validFrom, validTo)
        {
            Weekdays = weekdays;
        }

        public DayOfWeek[] Weekdays { get; set; }
    }
}