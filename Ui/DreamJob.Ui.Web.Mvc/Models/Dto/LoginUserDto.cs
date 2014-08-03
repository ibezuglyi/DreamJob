using DreamJob.Common.Enum;

namespace DreamJob.Ui.Web.Mvc.Models.Dto
{
    public class LoginUserDto
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public bool PersistentLogin { get; set; }

        public UserAccountType UserAccountType{ get; set; }
    }
}