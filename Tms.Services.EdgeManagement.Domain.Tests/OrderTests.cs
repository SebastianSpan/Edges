// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Xunit;

// namespace Tms.Services.EdgeManagement.Domain.Commands.Tests
// {
//     public class OrderTests
//     {
//         private static ContainerType Kiste = new ContainerType { Id = 1, Name = "Kiste" };
//         private static ProductType Kiwi = new ProductType { Id = 1, Name = "Kiwi" };
//         private static ProductType Banane = new ProductType { Id = 1, Name = "Banane" };

//         [Fact]
//         public async void Add_OneKisteOfKiwis_ShouldBeCorrect()
//         {
//             // Prepare
//             var testee = new Order();

//             // Execute
//             testee.Positions.Add(new OrderPosition(1, Kiste, Kiwi));

//             // Verify
//             Assert.Equal(1, testee.Positions.Count);
//             Assert.Equal(Kiste, testee.Positions[0].Container);
//             Assert.Equal(1, testee.Positions[0].Quantity);
//         }

//         [Fact]
//         public async void Add_OneKisteOfKiwisAndOneKisteOfBananas_ShouldBeCorrect()
//         {
//             // Prepare
//             var testee = new Order();

//             // Execute
//             testee.Positions.Add(new OrderPosition(1, Kiste, Kiwi));
//             testee.Positions.Add(new OrderPosition(1, Kiste, Banane));

//             // Verify
//             Assert.Equal(2, testee.Positions.Count);
//             Assert.Equal(Kiste, testee.Positions[0].Container);
//             Assert.Equal(Kiste, testee.Positions[1].Container);
//             Assert.Equal(1, testee.Positions[0].Quantity);
//             Assert.Equal(1, testee.Positions[1].Quantity);
//             Assert.NotNull(testee.Positions[0].Product == Kiwi);
//             Assert.NotNull(testee.Positions[1].Product == Banane);
//         }
//     }

    
// }