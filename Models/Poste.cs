using System;
using System.Collections.Generic;

namespace WebApi10.Models
{
    public partial class Poste
    {
        public Poste()
        {
            Equipement = new HashSet<Equipement>();
        }

        public string Nom { get; set; }
        public string IpAdresse { get; set; }
        public string NomUtilisateur { get; set; }
        public bool IsBureau { get; set; }
        public int IdLocal { get; set; }

        public Local IdLocalNavigation { get; set; }
        public ICollection<Equipement> Equipement { get; set; }
    }
}
