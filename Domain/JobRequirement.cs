﻿namespace DreamJob.Domain.Models
{
    public class JobRequirement
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public CurrencyType Currency { get; set; }
        public decimal CurrencyAmount { get; set; }
        public Location JobLocation { get; set; }
    }
}