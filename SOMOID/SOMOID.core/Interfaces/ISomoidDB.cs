using SOMOID.core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SOMOID.core.Interfaces
{
    public interface ISomoidDB
    {
        string GetUserPassword(Guid originUser);
        Application CreateApplication(Application model);

    }
}
