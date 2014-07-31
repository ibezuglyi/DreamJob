using System.Collections.Generic;

namespace DreamJob.Model.Domain
{
    using System;

    using DreamJob.Common.Enum;

    public abstract class User : BaseEntity
    {
        public string Login { get; set; }
        public string DisplayName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public UserAccountType AccountType { get; set; }
        
        public long? ConfirmationId { get; set; }
        public List<Confirmation> Confirmations { get; set; }
        
        public bool IsActive { get; set; }

        public DateTime Registered { get; set; }
        public DateTime LastLoginDateTime { get; set; }

        protected User()
        {
            this.Confirmations = new List<Confirmation>();
        }
    }
}