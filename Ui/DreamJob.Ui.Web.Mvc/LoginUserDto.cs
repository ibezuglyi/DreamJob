namespace DreamJob.Ui.Web.Mvc
{
    public class LoginUserDto
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public bool PersistentLogin { get; set; }
    }
}