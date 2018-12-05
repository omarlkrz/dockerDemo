using System;
using System.Collections.Generic;

namespace WebApi10.Models
{
    public partial class Local
    {
        public Local()
        {
            Poste = new HashSet<Poste>();
        }

        public int IdLocal { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Responsable { get; set; }
        public int CodeEmplacement { get; set; }
        public int IdTypeLocal { get; set; }

        public Emplacement CodeEmplacementNavigation { get; set; }
        public TypeLocal IdTypeLocalNavigation { get; set; }
        public ICollection<Poste> Poste { get; set; }
    }
}
