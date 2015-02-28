namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class ProfileLoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}