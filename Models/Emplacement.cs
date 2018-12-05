using System;
using System.Collections.Generic;

namespace WebApi10.Models
{
    public partial class Emplacement
    {
        public Emplacement()
        {
            Local = new HashSet<Local>();
        }

        public int CodeEmplacement { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public ICollection<Local> Local { get; set; }
    }
}
