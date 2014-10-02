namespace DreamJob.Ui.Web.Mvc.Helpers
{
    using System;
    using System.Text;

    public class GuidAdapter : IGuidAdapter
    {
        public Guid New
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        public string GetTimesBy(int counts)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < counts; i++)
            {
                sb.Append(Guid.NewGuid().ToString());
            }

            var withoutDashes = sb.Replace("-", string.Empty);
            var result = withoutDashes.ToString().ToUpper();
            return result;
        }
    }
}