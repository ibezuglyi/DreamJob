using System.Text;

namespace DreamJob.Ui.Web.Mvc.Controllers
{
    public class AcceptOfferDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string ContactMethod { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Name: {0}<br/>", this.Name);
            sb.AppendFormat("Note: {0}<br/>", this.Note);
            sb.AppendFormat("ContactMethod: {0}<br/>", this.ContactMethod);
            sb.AppendFormat("Email: {0}<br/>", this.Email);
            sb.AppendFormat("Phone: {0}<br/>", this.Phone);

            return sb.ToString();
        }
    }
}