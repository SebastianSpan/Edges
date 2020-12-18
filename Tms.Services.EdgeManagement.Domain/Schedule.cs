using System;
using System.Collections.Generic;

namespace Tms.Services.EdgeManagement.Domain
{
    public abstract class Schedule
    {
        public Schedule(DateTime validFrom, TimeSpan? timeWindowFrom, TimeSpan? timeWindowTo, DateTime? validTo = null)
        {
            ValidFrom = validFrom;
            ValidTo = validTo;            
            TimeWindowFrom = timeWindowFrom.HasValue ? timeWindowFrom.Value : new TimeSpan(00, 00, 00);
            TimeWindowTo = timeWindowTo.HasValue ? timeWindowTo.Value : new TimeSpan(00, 00, 00);
        }

        public DateTime ValidFrom { get; private set; }

        public DateTime? ValidTo { get; private set; }

        public TimeSpan TimeWindowFrom { get; set; }

        public TimeSpan TimeWindowTo { get; set; }
    }

    public class DaySchedule : Schedule
    {
        public DaySchedule(DateTime day, TimeSpan? timeWindowFrom = null, TimeSpan? timeWindowTo = null)
            : base(day, timeWindowFrom, timeWindowTo, day)
        {
            Day = day;
        }

        public DateTime Day { get; set; }
    }

    public class WeeklySchedule : Schedule
    {
        public WeeklySchedule(DateTime validFrom, DayOfWeek[] weekdays, TimeSpan? timeWindowFrom = null, TimeSpan? timeWindowTo = null, DateTime? validTo = null)
            : base(validFrom, timeWindowFrom, timeWindowTo, validTo)
        {
            Weekdays = weekdays;
        }

        public DayOfWeek[] Weekdays { get; set; }
    }
}