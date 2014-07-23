﻿namespace DreamJob.Model.Domain
{
    using DreamJob.Common.Enum;

    public class SalaryRange:BaseEntity
    {
        public long Low { get; set; }
        public long High { get; set; }
        public Currency Currency { get; set; }
    }
}