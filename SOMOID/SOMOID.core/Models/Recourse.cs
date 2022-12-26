using System;

namespace SOMOID.core.Models
{
    public class Recourse
    {
        protected int Id;

        protected string Name;

        public string GetName()
        {
            return Name;
        }

        public string SetName(string name)
        {
            return Name = name;
        }

    }
}
