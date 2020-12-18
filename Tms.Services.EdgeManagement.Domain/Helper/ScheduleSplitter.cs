using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tms.Services.EdgeManagement.Domain.Services;

namespace Tms.Services.EdgeManagement.Domain.Helper
{
    public static class ScheduleSplitter
    {
        public static IList<(TObject Item, Schedule Schedule)> SplitSchedules<TObject>(
            IEnumerable<(TObject Item, Schedule Schedule)> possibleSchedules, 
            Schedule schedule)
        {
            var result = new List<(TObject Item, Schedule Schedule)>();
            
            foreach(var s in possibleSchedules)
            {
                if(s.Schedule.ValidFrom > schedule.ValidFrom)
                {
                    continue;
                }

                if(!s.Schedule.ValidTo.HasValue || s.Schedule.ValidTo >= schedule.ValidTo)
                {
                    if(s.Schedule is WeeklySchedule)
                    {
                        var w = (WeeklySchedule)s.Schedule;
                        if(schedule is DaySchedule)
                        {                            
                            var d = (DaySchedule)schedule;
                            if(w.Weekdays.Contains(d.Day.DayOfWeek))
                            {
                                return new List<(TObject Item, Schedule Schedule)>(new []{(s.Item, (Schedule)new DaySchedule(d.Day, d.TimeWindowFrom, d.TimeWindowTo))});
                            }
                        }
                        else if(schedule is WeeklySchedule)
                        {
                            var w1 = (WeeklySchedule)schedule;
                            var missing = new List<DayOfWeek>();
                            foreach(var weekday in w1.Weekdays)
                            {
                                if(w.Weekdays.Contains(weekday))
                                {

                                }
                            }
                        }
                    }
                }
                else
                {
                    continue;
                }
            }

            return result;
        }
    }
}