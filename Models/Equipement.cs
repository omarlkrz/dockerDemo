using System;
using System.Collections.Generic;

namespace WebApi10.Models
{
    public partial class Equipement
    {
        public Equipement()
        {
            Mouvement = new HashSet<Mouvement>();
        }

        public string Sn { get; set; }
        public DateTime DateCreation { get; set; }
        public string Inventory { get; set; }
        public string Propriete { get; set; }
        public string CodeModel { get; set; }
        public string NomPoste { get; set; }

        public Modele CodeModelNavigation { get; set; }
        public Poste NomPosteNavigation { get; set; }
        public ICollection<Mouvement> Mouvement { get; set; }
    }
}
