namespace DreamJob.Ui.Web.Mvc.Models.Dto
{
    using DreamJob.Common.Enum;

    public class LoginUserDto
    {
        public long Id { get; set; }

        public string DisplayName { get; set; }

        public bool PersistentLogin { get; set; }

        public UserAccountType UserAccountType { get; set; }
    }
}