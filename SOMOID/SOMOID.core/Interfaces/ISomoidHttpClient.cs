using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SOMOID.core.Interfaces
{
    public interface ISomoidHttpClient
    {
        //aqui colocamos os metodos para cliente ligar a api crud
        Task<string> Ping();
    }
}
