using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    public interface IErrorsBusiness
    {
        void SendEmailOnInternalError(Exception exception);
    }
}
