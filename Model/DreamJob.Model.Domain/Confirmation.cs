using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamJob.Model.Domain
{
    public class Confirmation : BaseEntity
    {
        
        public string ConfirmationCode { get; set; }

        public Confirmation()
        {
            
        }

        public Confirmation(string hash)
        {
            this.ConfirmationCode = hash;
        }
    }
}
