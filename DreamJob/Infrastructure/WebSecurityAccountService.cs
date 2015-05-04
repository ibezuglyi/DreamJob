
namespace DreamJob.Infrastructure
{
    using System;
    using System.Linq;
    using System.Web.Security;
    using Dtos;
    using ViewModels;
    using WebMatrix.WebData;

    class WebSecurityAccountService : IAccountService
    {
        public void Logout()
        {
            WebSecurity.Logout();
        }

        public bool Login(ProfileLoginDto dto)
        {
            var result = WebSecurity.Login(dto.Email, dto.Password, dto.RememberMe);
            return result;
        }

        public void RegisterDeveloper(ProfileRegisterDto dto)
        {
            WebSecurity.CreateUserAndAccount(
                dto.Email,
                dto.Password,
                new { Role = ApplicationUserRole.Developer, CreateDateTime = DateTime.Now });
            Roles.AddUserToRole(dto.Email, "Developer");
        }

        public void RegisterRecruiter(ProfileRegisterDto dto)
        {
            WebSecurity.CreateUserAndAccount(
                dto.Email,
                dto.Password,
                new { Role = ApplicationUserRole.Recruiter, CreateDateTime = DateTime.Now });
            Roles.AddUserToRole(dto.Email, "Recruiter");
        }

        public long GetCurrentLoggedUserId()
        {
            return WebSecurity.CurrentUserId;
        }

        public ApplicationUserRole GetCurrentLoggedUserRole()
        {
            var allRoles = Roles.GetRolesForUser(WebSecurity.CurrentUserName);
            if (allRoles.Any())
            {
                var roleName = allRoles.First();
                ApplicationUserRole result;
                if (Enum.TryParse(roleName, out result))
                {
                    return result;
                }
            }
            return ApplicationUserRole.Anonymous;
        }
    }
}