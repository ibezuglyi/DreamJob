using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DreamJob.Common.Enum;
using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc.Services
{
    using DreamJob.Ui.Web.Mvc.Controllers;

    public interface IRecruiterService
    {
        DjOperationResult<UserProfileDto> GetRecruiterPublicProfile(long id);
        void UpdateRecruiterProfile(SaveRecruiterProfileDto model);
    }
}