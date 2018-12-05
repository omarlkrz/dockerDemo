using System;
using System.Collections.Generic;

namespace WebApi10.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            Modele = new HashSet<Modele>();
        }

        public int IdVendor { get; set; }
        public string Description { get; set; }

        public ICollection<Modele> Modele { get; set; }
    }
}
