namespace Tms.Services.EdgeManagement.Domain
{
    public class TransportPlanElement
    {
        public long Id { get; set; }

        public long TransportPlanId { get; set; }

        public TransportPlan TransportPlan { get; set; }
    }
}