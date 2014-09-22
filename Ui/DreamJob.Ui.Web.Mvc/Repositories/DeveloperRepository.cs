using System.Data.Entity;
using System.Data.Entity.Migrations;
using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using DreamJob.Common.Enum;
    using DreamJob.Database.EntityFramework;
    using DreamJob.Model.Domain;

    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly DreamJobContext context;

        public DeveloperRepository(DreamJobContext context)
        {
            this.context = context;
        }

        public void Add(Developer developer)
        {
            this.context.Developers.Add(developer);
            this.context.SaveChanges();
        }

        public void ConfirmDeveloperRegistration(string hash)
        {
            var developer = this.context.Developers.SingleOrDefault(r => r.Confirmations.Any(t => t.ConfirmationCode == hash));
            if (developer != null)
            {
                this.context.Entry(developer).Collection(r => r.Confirmations).Load();
                var confirmation = developer.Confirmations.Single(r => r.ConfirmationCode == hash);
                developer.Confirmations.Remove(confirmation);
                developer.IsActive = true;
                this.context.SaveChanges();
            }
        }

        public DjOperationResult<List<Developer>> All()
        {
            var all = this.context.Developers.ToList();
            var operationResult = new DjOperationResult<List<Developer>>(all);
            return operationResult;
        }

        public DjOperationResult<Developer> GetById(long developerId)
        {
            var developer = this.context.Developers
                .Include(t => t.Skills)
                .SingleOrDefault(d => d.Id == developerId);

            var result = new DjOperationResult<Developer>(developer);
            return result;
        }

        public void UpdateDeveloper(Developer developer)
        {
            context.Developers.AddOrUpdate(developer);
            context.SaveChanges();
        }

        public List<string> GetDeveloperCities(string cityPart)
        {
            return context.Developers.Select(r => r.City)
                .Where(t => t.Contains(cityPart))
                .Distinct()
                .ToList();
        }

        public List<Developer> SearchForDevelopers(string technology, string city)
        {
            var query = context.Developers.Where(r => r.IsActive);
            if (!string.IsNullOrEmpty(technology))
            {
                var technologyLower = technology.ToLower();
                query = query.Where(r =>
                    r.Profile.ToLower().Contains(technologyLower) ||
                    r.ProjectPreferences.ToLower().Contains(technologyLower) ||
                    r.Skills.Any(t => t.Description.ToLower().Contains(technology.ToLower())) ||
                    r.Title.ToLower().Contains(technology.ToLower()));
            }
            if (!string.IsNullOrEmpty(city))
            {
                var cityLower = city.ToLower();
                query = query.Where(r => !string.IsNullOrEmpty(r.City) && r.City.ToLower() == cityLower);
            }

            return query
                .OrderByDescending(r => r.Registered)
                .Take(50)
                .ToList();

        }

        public void RemoveAllSkillsForDeveloper(long id)
        {
            var developer = context.Developers.Single(r => r.Id == id);
            foreach (var skill in developer.Skills)
            {
                context.Entry(skill).State = EntityState.Deleted;
            }
            context.SaveChanges();
        }
    }
}