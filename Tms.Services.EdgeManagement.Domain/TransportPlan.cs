namespace Tms.Services.EdgeManagement.Domain
{
    public class TransportPlan
    {
        public long Id { get; set; }

        public long OriId { get; set; }

        public Schedule Schedule { get; set; }
    }
}