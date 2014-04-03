namespace DreamJob.Domain.Models
{
    public class JobRequirement
    {
        public string Description { get; set; }
        public CurrencyType Currency { get; set; }
        public decimal CurrencyAmount { get; set; }
        public Location JobLocation { get; set; }
    }
}