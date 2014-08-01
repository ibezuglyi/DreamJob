namespace DreamJob.Ui.Web.Mvc.Areas.Api.Controllers
{
    using System.Collections.Generic;

    using DreamJob.Model.Domain;

    public interface IOffersRepository
    {
        List<JobOffer> OffersTo(long userId);
    }
}