using System.Collections.Generic;

namespace Tms.Services.EdgeManagement.Domain
{
    public class Edge
    {
        public Edge(
            Node origin, 
            Node destination, 
            Schedule schedule, 
            double distanceLinearInKilometer, 
            double distanceEstimatedInKilometer = -1, 
            Edge parent = null)
        {
            Origin = origin;
            Destination = destination;
            Schedule = schedule;
            DistanceLinearInKilometer = distanceLinearInKilometer;
            DistanceEstimatedInKilometer = distanceEstimatedInKilometer < 0 ? distanceLinearInKilometer : distanceEstimatedInKilometer;
            Children = new List<Edge>();
            Siblings = new List<Edge>();
        }

        public int Id { get; set; }

        public Edge Parent { get; set; }

        public List<Edge> Children { get; private set; }
    
        public List<Edge> Siblings { get; private set; }
        
        public Node Origin { get; set; }

        public Node Destination { get; set; }

        public Schedule Schedule { get; set; }

        public ContainerType Container { get; set; }

        public decimal Quantity { get; set; }

        public ProductType Product { get; set; }

        public double DistanceLinearInKilometer { get; set; }

        public double DistanceEstimatedInKilometer { get; set; }
    }
}