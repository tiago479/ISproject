using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectIS.Model
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Created_at { get; set; }
        public int Application_Id { get; set; }
    }
}