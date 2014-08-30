namespace DreamJob.Ui.Web.Mvc.Repositories
{
    using System.Collections.Generic;

    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;

    public interface IDeveloperRepository
    {
        void Add(Developer developer);
        void ConfirmDeveloperRegistration(string hash);

        DjOperationResult<List<Developer>> All();

        DjOperationResult<Developer> GetById(long developerId);
        void UpdateDeveloper(Developer developer);
    }
}