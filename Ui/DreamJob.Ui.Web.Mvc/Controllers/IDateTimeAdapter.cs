namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System;

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