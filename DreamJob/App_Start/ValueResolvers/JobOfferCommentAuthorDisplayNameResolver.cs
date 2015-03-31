namespace DreamJob.ValueResolvers
{
    using AutoMapper;
    using Models;
    using ViewModels;

    public class JobOfferCommentAuthorDisplayNameResolver : ValueResolver<JobOfferComment, string>
    {
        protected override string ResolveCore(JobOfferComment source)
        {
            var result = source.AuthorRole == ApplicationUserRole.Developer
                ? source.Author.Developer.DisplayName
                : string.Format("{0} {1}", source.Author.Recruiter.FirstName, source.Author.Recruiter.LastName);
            return result;
        }
    }
}