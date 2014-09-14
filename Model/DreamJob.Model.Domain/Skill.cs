using System.Security;
using System.Security.AccessControl;

namespace DreamJob.Model.Domain
{
    using System.Collections.Generic;

    public class Skill : BaseEntity
    {
        public string Description { get; set; }
        public int SelfRate { get; set; }

    }
}