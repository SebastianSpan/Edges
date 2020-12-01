using System;
using System.Collections.Generic;

namespace Tms.Services.EdgeManagement.Domain
{
    public class Schedule
    {
        public Schedule(DateTime validFrom, TimeSpan timeWindowFrom, TimeSpan timeWindowTo, DateTime? validTo = null)
        {
            ValidFrom = validFrom;
            ValidTo = validTo;            
            TimeWindowFrom = timeWindowFrom;
            TimeWindowTo = timeWindowTo;
        }

        public DateTime ValidFrom { get; private set; }

        public DateTime? ValidTo { get; private set; }

        public TimeSpan TimeWindowFrom { get; set; }

        public TimeSpan TimeWindowTo { get; set; }
    }

    public class DaySchedule : Schedule
    {
        public DaySchedule(DateTime day, TimeSpan timeWindowFrom, TimeSpan timeWindowTo)
            : base(day, timeWindowFrom, timeWindowTo, day)
        {
            Day = day;
        }

        public DateTime Day { get; set; }
    }

    public class WeeklySchedule : Schedule
    {
        public WeeklySchedule(DateTime validFrom, DayOfWeek[] weekdays, TimeSpan timeWindowFrom, TimeSpan timeWindowTo, DateTime? validTo = null)
            : base(validFrom, timeWindowFrom, timeWindowTo, validTo)
        {
            Weekdays = weekdays;
        }

        public DayOfWeek[] Weekdays { get; set; }
    }
}