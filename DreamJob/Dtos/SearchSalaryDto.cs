namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class SearchSalaryDto
    {
        [Required]
        public decimal Minimum { get; set; }

        [Required]
        public decimal Maximum { get; set; }
    }
}