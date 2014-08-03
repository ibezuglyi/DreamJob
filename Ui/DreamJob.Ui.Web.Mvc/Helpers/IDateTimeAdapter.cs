using System;

namespace DreamJob.Ui.Web.Mvc.Helpers
{
    public interface IDateTimeAdapter
    {
        DateTime Now { get; }
    }

    class DateTimeAdapter : IDateTimeAdapter
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}