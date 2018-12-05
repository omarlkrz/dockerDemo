using System;
using System.Collections.Generic;

namespace WebApi10.Models
{
    public partial class TypeDevice
    {
        public TypeDevice()
        {
            Modele = new HashSet<Modele>();
        }

        public int IdTypeDev { get; set; }
        public string Description { get; set; }

        public ICollection<Modele> Modele { get; set; }
    }
}
