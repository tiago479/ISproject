using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectIS.Model
{
    public class Data : RequestType
    {
        public string Content { get; set; }

        public int Parent { get; set; }
    }
}