using System;
using System.ComponentModel.DataAnnotations;

namespace SOMOID.Models
{
    public class Recourse
    {
        protected int id;
        protected string name;
        protected DateTime creation_dt;

        protected int Id { get => id; }
        protected string Name { get => name; set => name = value; }
        protected DateTime Creation_dt { get => creation_dt; }

        public Recourse(int id, string name)
        {
            this.id = id;
            this.name = name;
            creation_dt = DateTime.Now;
        }

    }
}
