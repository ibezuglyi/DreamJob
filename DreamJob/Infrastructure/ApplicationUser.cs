namespace DreamJob.Infrastructure
{
    using ViewModels;

    public class ApplicationUser
    {
        public long Id { get; set; }
        public ApplicationUserRole Role { get; set; }
    }
}