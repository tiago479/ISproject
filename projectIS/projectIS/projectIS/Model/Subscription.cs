using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectIS.Model
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Created_at { get; set; }
        public int SubscriptionId { get; set; }
        public string Event { get; set; }
        public string EndPoint { get; set; }
    }
}