using System;
using System.Collections.Generic;
using Tms.Services.EdgeManagement.Domain.EventHandler;
using Xunit;

namespace Tms.Services.EdgeManagement.Domain
{
    public class NewOrderCommandTests
    {
        [Fact]
        public async void ExecuteAsync_asdf()
        {
            // Prepare
            var testee = new NewOrderCommand(null);
            var order = OrderBuilder
                .At(Locations.KölnerDom)
                .From(2020, 11, 28)
                .To(2020, 12, 31)
                .Every(DayOfWeek.Monday, DayOfWeek.Tuesday)
                .Between(new TimeSpan(16, 00, 00), new TimeSpan(17, 30, 00))
                .Load(2, ContainerTypes.Kiste, ProductTypes.Brief)
                .Load(3, ContainerTypes.Kiste, ProductTypes.Paket)
                .Build();

            // Execute

            // Verify
            await testee.ExecuteAsync(order);
        }
    }

    public class OrderBuilder : IFromExpression, IValidFromExpression, IValidToExpression, ITimeWindowExpression, IBetweenExpression, ILoadExpression
    {
        private Location _location;
        private DateTime _validFrom;

        private DateTime? _validTo;

        private Schedule _schedule;

        private TimeSpan _earliestArrival;
        private TimeSpan _lastestArrival; 
        private List<OrderPosition> _positions = new List<OrderPosition>();

        private OrderBuilder()
        {

        }
        public static IFromExpression At(Location location)
        {
            var builder = new OrderBuilder();
            builder._location = location;

            return builder;
        }

        public IBetweenExpression Between(TimeSpan from, TimeSpan to)
        {
            _earliestArrival = from;
            _lastestArrival = to;

            return this;
        }

        public Order Build()
        {
            var order = new Order()
            {
                Location = _location,
                Schedule = _schedule
            };

            foreach(var p in _positions)
            {
                p.Order = order;
                order.Positions.Add(p);
            }

            return order;
        }

        public ITimeWindowExpression Every(params DayOfWeek[] weekdays)
        {
            _schedule = new WeeklySchedule(_validFrom, weekdays, _earliestArrival, _lastestArrival, _validTo);

            return this;
        }

        public ITimeWindowExpression On(DateTime day)
        {
            _schedule = new DaySchedule(day, _earliestArrival, _lastestArrival);

            return this;
        }

        public IValidFromExpression From(int year, int month, int day)
        {
            _validFrom = new DateTime(year, month, day);

            return this;
        }

        public ILoadExpression Load(decimal quantity, ContainerType container, ProductType product)
        {
            _positions.Add(new OrderPosition(quantity,container,product));

            return this;
        }

        public IValidToExpression To(int year, int month, int day)
        {
            _validTo = new DateTime(year, month, day);

            return this;
        }
    }

    public interface IFromExpression
    {
        IValidFromExpression From(int year, int month, int day);
        
    }

    public interface IValidFromExpression
    {
        IValidToExpression To(int year, int month, int day);
        ITimeWindowExpression Every(params DayOfWeek[] weekdays);  
        ITimeWindowExpression On(DateTime day);      
    }

    public interface IValidToExpression
    {
        ITimeWindowExpression Every(params DayOfWeek[] weekdays);
        ITimeWindowExpression On(DateTime day);
    }

    public interface ITimeWindowExpression
    {
        IBetweenExpression Between(TimeSpan from, TimeSpan to);
    }

    public interface IBetweenExpression
    {
        ILoadExpression Load(decimal quantity, ContainerType container, ProductType productType);    
    }

    public interface ILoadExpression
    {
        ILoadExpression Load(decimal quantity, ContainerType container, ProductType productType);
        Order Build();
    }
}
