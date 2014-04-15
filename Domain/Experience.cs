namespace DreamJob.Domain.Models
{
    using System;
    using System.Collections.Generic;

    public class Experience
    {
        public long Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; }
    }
}