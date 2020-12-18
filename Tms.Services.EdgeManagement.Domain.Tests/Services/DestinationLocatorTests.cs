using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tms.Services.EdgeManagement.Domain.Services
{
    public class DestinationLocatorTests
    {
        [Fact]
        public async void Ctor_IfDestinationNodesIsNull_ArgumentNullExceptionIsThrown()
        {
            // Prepare

            // Execute

            // Verify
            Assert.Throws<ArgumentNullException>(() => { new DestinationLocator(null); });
        }

        [Fact]
        public async void sdf()
        {
            // Prepare
            var expectedDestination = new DestinationNode 
            { 
                AcceptedProducts = new List<ProductType>(new []
                {
                    ProductTypes.Paket
                }),
                Location = Locations.PZ_50
            };
            var testee = new DestinationLocator(new []
            {
                expectedDestination
            });

            var order = OrderBuilder
                .At(Locations.KölnerDom)
                .From(2020, 12, 07)
                .Every(DayOfWeek.Monday)
                .Between(new TimeSpan(16, 00, 00), new TimeSpan(20, 00, 00))
                .Load(1, ContainerTypes.Kiste, ProductTypes.Paket)
                .Build();

            // Execute
            var result = await testee.GetDestination(order.Positions.First());

            // Verify
            Assert.Equal<DestinationNode>(expectedDestination, result);
        }
    }
}