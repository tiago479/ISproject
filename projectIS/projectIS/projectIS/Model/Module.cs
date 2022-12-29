using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectIS.Model
{
    public class Module : RequestType
    {
        public string Name { get; set; }
        public int Parent { get; set; }
        private List<Data> Datas { get; set; }
        private List<Subscription> Subscriptions { get; set; }
    }
}