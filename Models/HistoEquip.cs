using System;
using System.Collections.Generic;

namespace WebApi10.Models
{
    public partial class HistoEquip
    {
        public HistoEquip()
        {
            HistoMouv = new HashSet<HistoMouv>();
        }

        public string Sn { get; set; }
        public string CodeModel { get; set; }
        public DateTime DateH { get; set; }
        public DateTime DateCreation { get; set; }
        public string Inventory { get; set; }

        public Modele CodeModelNavigation { get; set; }
        public ICollection<HistoMouv> HistoMouv { get; set; }
    }
}
