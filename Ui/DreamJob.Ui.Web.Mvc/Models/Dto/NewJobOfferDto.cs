namespace DreamJob.Ui.Web.Mvc.Models.Dto
{
    public class NewJobOfferDto
    {
        public long DeveloperId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string MinSalary { get; set; }
        public string MaxSalary { get; set; }
        public bool MatchesDeveloperRequirements { get; set; }
    }
}