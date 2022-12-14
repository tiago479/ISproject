using SOMOID.core.Interfaces;
using SOMOID.core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppB
{
    public sealed class AppSingleton
    {
        private static AppSingleton _instance;
        public static ISomoidHttpClient ApiClient { get; set; }
        public AppSingleton()
        {
            var apiClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:27711")
            };
            ApiClient = new SomoidHttpClient(apiClient);
        }
        public static AppSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AppSingleton();
            }
            return _instance;
        }

    }
}
