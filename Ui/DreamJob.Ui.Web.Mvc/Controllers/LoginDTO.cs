namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.ComponentModel.DataAnnotations;

    public class LoginDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public bool PersistentLogin { get; set; }
    }
}