using System;
using System.Collections.Generic;

namespace WebApi10.Models
{
    public partial class Modele
    {
        public Modele()
        {
            Equipement = new HashSet<Equipement>();
            HistoEquip = new HashSet<HistoEquip>();
        }

        public string CodeModel { get; set; }
        public string Description { get; set; }
        public bool? SnDetectable { get; set; }
        public bool? ModelDetectable { get; set; }
        public string Propriete { get; set; }
        public int CodeVendor { get; set; }
        public int IdTypeDev { get; set; }

        public Vendor IdTypeDev1 { get; set; }
        public TypeDevice IdTypeDevNavigation { get; set; }
        public ICollection<Equipement> Equipement { get; set; }
        public ICollection<HistoEquip> HistoEquip { get; set; }
    }
}
