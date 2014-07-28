namespace DreamJob.Model.Domain
{
    using System;

    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public DateTime Add { get; set; }
        public DateTime Edit { get; set; }

    }
}