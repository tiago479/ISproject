using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SOMOID.core.Interfaces
{
    public interface ISomoidHttpClient
    {
        Task<string> Ping();
    }
}
