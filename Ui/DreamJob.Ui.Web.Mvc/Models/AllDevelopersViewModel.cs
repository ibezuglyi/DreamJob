namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Collections.Generic;

    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public class AllDevelopersViewModel
    {
        public AllDevelopersViewModel(List<DeveloperShortInformationDto> data)
        {
            this.Developers = data;
        }

        public List<DeveloperShortInformationDto> Developers { get; set; }
    }
}