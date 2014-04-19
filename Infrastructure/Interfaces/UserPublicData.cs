using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamJob.Infrastructure.Interfaces
{
    using DreamJob.Domain.Models;

    public class UserPublicData
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public UserAccountType AccountType { get; set; }
    }
}
