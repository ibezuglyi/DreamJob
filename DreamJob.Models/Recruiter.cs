namespace DreamJob.Models
{
    public class Recruiter : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Company Company { get; set; }
    }
}