using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectIS.Model
{
    public class Data : ResourceType
    {
        public string Content { get; set; }
        public string OldContent { get; set; }
        public int Parent { get; set; }
    }
}