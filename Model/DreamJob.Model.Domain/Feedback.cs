namespace DreamJob.Model.Domain
{
    using DreamJob.Common.Enum;

    public class Feedback : BaseEntity
    {
        public Recruiter Recruiter { get; set; }
        public long RecruiterId { get; set; }

        public Developer Developer { get; set; }
        public long DeveloperId { get; set; }

        public string Text { get; set; }

        public FeedbackKind FeedbackKind { get; set; }
    }
}