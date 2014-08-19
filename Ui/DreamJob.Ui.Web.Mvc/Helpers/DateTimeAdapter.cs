namespace DreamJob.Ui.Web.Mvc.Helpers
{
    using System;

    public class DateTimeAdapter : IDateTimeAdapter
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