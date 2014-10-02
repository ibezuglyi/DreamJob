namespace DreamJob.Model.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class BaseEntity
    {
        public long Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Add { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Edit { get; set; }
    }
}