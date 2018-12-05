using System;
using System.Collections.Generic;

namespace WebApi10.Models
{
    public partial class User
    {
        public User()
        {
            HistoMouv = new HashSet<HistoMouv>();
            Mouvement = new HashSet<Mouvement>();
        }

        public string IdUser { get; set; }
        public string Nom { get; set; }
        public string Password { get; set; }
        public string Courriel { get; set; }
        public bool Actif { get; set; }
        public int IdUserType { get; set; }

        public UserType IdUserTypeNavigation { get; set; }
        public ICollection<HistoMouv> HistoMouv { get; set; }
        public ICollection<Mouvement> Mouvement { get; set; }
    }
}
