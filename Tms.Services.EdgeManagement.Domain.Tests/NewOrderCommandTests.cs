using System;
using System.Collections.Generic;
using Xunit;

namespace Tms.Services.EdgeManagement.Domain.Commands.Tests
{
    public class NewOrderCommandTests
    {
        private static ContainerType Kiste = new ContainerType { Id = 1, Name = "Kiste" };

        private static ContainerType Sack = new ContainerType { Id = 2, Name = "Sack" };

        private static ProductType Kiwi = new ProductType { Id = 1, Name = "Kiwi" };

        private static ProductType Banane = new ProductType { Id = 2, Name = "Banane" };

        private static ProductType Nuss = new ProductType { Id = 3, Name = "Nuss" };

        private static Location KölnerDom = new Location{ Name = "Kölner Dom", Position = new GeoPosition{Longitude = 50.9413, Latitude = 6.9583} };

        private static Location PZ_50 = new Location{ Name = "Kölner Dom", Position = new GeoPosition{Longitude = 50.886129, Latitude = 6.919789} };

        [Fact]
        public async void ExecuteAsync_IfOrderIsNull_ArgumentNullExceptionIsThrown()
        {
            // Prepare
            var testee = new NewOrderCommand(null);

            // Execute

            // Verify
            await Assert.ThrowsAsync<ArgumentNullException>(()=> testee.ExecuteAsync(null));
        }

        [Fact]
        public async void ExecuteAsync_IfOrderIsWithoutPositions_InvalidOperationIsThrown()
        {
            // Prepare
            var testee = new NewOrderCommand(null);
            var order = new Order();

            // Execute

            // Verify
            await Assert.ThrowsAsync<InvalidOperationException>(()=> testee.ExecuteAsync(order));
        }

        [Fact]
        public async void ExecuteAsync_asdf()
        {
            // Prepare
            var testee = new NewOrderCommand(null);
            var order = OrderBuilder
                .At(KölnerDom)
                .From(2020, 11, 28)
                .To(2020, 12, 31)
                .Every(DayOfWeek.Monday, DayOfWeek.Tuesday)
                .Between(new TimeSpan(16, 00, 00), new TimeSpan(17, 30, 00))
                .Pickup(2, Kiste, Banane)
                .Pickup(3, Kiste, Kiwi)
                .Pickup(10, Sack, Nuss)
                .Pickup(1, Kiste, new Load(Banane,0.4), new Load(Kiwi, 0.6))
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

        public ILoadExpression Pickup(int quantity, ContainerType container, ProductType product)
        {
            _positions.Add(new OrderPosition(quantity,container,product));

            return this;
        }

        public ILoadExpression Pickup(int quantity, ContainerType container, params Load[] loads)
        {
            _positions.Add(new OrderPosition(quantity, container, loads));

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
        ILoadExpression Pickup(int quantity, ContainerType container, ProductType productType);    
        ILoadExpression Pickup(int quantity, ContainerType container, params Load[] loads);
    }

    public interface ILoadExpression
    {
        ILoadExpression Pickup(int quantity, ContainerType container, ProductType productType);
        ILoadExpression Pickup(int quantity, ContainerType container, params Load[] loads);
        Order Build();
    }
}
