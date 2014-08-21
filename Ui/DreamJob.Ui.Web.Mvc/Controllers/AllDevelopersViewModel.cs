namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Collections.Generic;

    public class AllDevelopersViewModel
    {
        public AllDevelopersViewModel(List<DeveloperShortInformationDto> data)
        {
            this.Developers = data;
        }

        public List<DeveloperShortInformationDto> Developers { get; set; }
    }

    public class DeveloperShortInformationDto
    {
        public string DisplayName { get; set; }
        public string City { get; set; }
    }
}