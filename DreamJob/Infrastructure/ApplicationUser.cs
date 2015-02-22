namespace DreamJob.Infrastructure
{
    using DreamJob.ViewModels;

    public class ApplicationUser
    {
        public long Id { get; set; }
        public ApplicationUserRole Role { get; set; }
    }
}