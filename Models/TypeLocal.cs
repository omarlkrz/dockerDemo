using System;
using System.Collections.Generic;

namespace WebApi10.Models
{
    public partial class TypeLocal
    {
        public TypeLocal()
        {
            Local = new HashSet<Local>();
        }

        public int IdTypeLocal { get; set; }
        public string NomTypeLocal { get; set; }

        public ICollection<Local> Local { get; set; }
    }
}
