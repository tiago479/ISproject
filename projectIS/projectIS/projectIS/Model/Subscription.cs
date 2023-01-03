using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectIS.Model
{
    public class Subscription : ResourceType
    {
        public string Name { get; set; }
        public int Parent { get; set; }
        public string EndPoint { get; set; }
        public string Event { get; set; }
    }
}