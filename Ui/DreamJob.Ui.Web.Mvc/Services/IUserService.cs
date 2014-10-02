namespace DreamJob.Ui.Web.Mvc.Services
{
    using System;

    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface IUserService
    {
        DjOperationResult<LoginUserDto> GetUserLoginDto(string login, string passwordHash);
        DjOperationResult<DateTime> GetAccountCreation(string login);
    }
}