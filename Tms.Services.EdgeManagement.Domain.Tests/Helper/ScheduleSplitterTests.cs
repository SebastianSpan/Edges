using System;
using System.Collections.Generic;
using System.Linq;
using Tms.Services.EdgeManagement.Domain.EventHandler;
using Tms.Services.EdgeManagement.Domain.Helper;
using Xunit;

namespace Tms.Services.EdgeManagement.Domain
{
    public class ScheduleSplitterTests
    {
        [Fact]
        public async void SplitSchedules_01()
        {
            // Prepare
            var schedules = new List<(string, Schedule)>();
            schedules.Add(("Depot 1", new WeeklySchedule(new DateTime(2020, 09, 18), new[]{DayOfWeek.Friday})));

            // Execute
            var result = ScheduleSplitter.SplitSchedules(schedules, new DaySchedule(new DateTime(2020, 09, 18)));

            // Verify
            Assert.Equal(1, result.Count());
            Assert.Equal("Depot 1", result[0].Item);
        }

        [Fact]
        public async void SplitSchedules_02()
        {
            // Prepare
            var schedules = new List<(string, Schedule)>();
            schedules.Add(("Depot 1", new WeeklySchedule(new DateTime(2020, 09, 19), new[]{ DayOfWeek.Friday })));

            // Execute
            var result = ScheduleSplitter.SplitSchedules(schedules, new DaySchedule(new DateTime(2020, 09, 18)));

            // Verify
            Assert.Equal(0, result.Count());
        }

        [Fact]
        public async void SplitSchedules_03()
        {
            // Prepare
            var schedules = new List<(string, Schedule)>();
            schedules.Add(("Depot 1", new WeeklySchedule(new DateTime(2000, 09, 10), new[]{ DayOfWeek.Thursday })));

            // Execute
            var result = ScheduleSplitter.SplitSchedules(schedules, new DaySchedule(new DateTime(2020, 09, 18)));

            // Verify
            Assert.Equal(0, result.Count());
        }
    }
}