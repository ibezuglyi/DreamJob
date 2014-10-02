namespace DreamJob.Ui.Web.Mvc.Helpers
{
    using System;

    public interface IGuidAdapter
    {
        Guid New { get; }
        string GetTimesBy(int counts);
    }
}