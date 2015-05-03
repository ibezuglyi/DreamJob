namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class SearchSalaryDto
    {
        [Required(
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "SearchSalary_Dto_Minimum_Required")]
        public decimal Minimum { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "SearchSalary_Dto_Maximum_Required")]
        public decimal Maximum { get; set; }
    }
}