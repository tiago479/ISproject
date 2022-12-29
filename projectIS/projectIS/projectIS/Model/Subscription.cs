using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectIS.Model
{
    public class Subscription : RequestType
    {
        public string Name { get; set; }
        public int Parent { get; set; }
        public string Event { get; set; }
        public string EndPoint { get; set; }
    }
}