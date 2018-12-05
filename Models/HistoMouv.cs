using System;
using System.Collections.Generic;

namespace WebApi10.Models
{
    public partial class HistoMouv
    {
        public int IdMouvement { get; set; }
        public string Sn { get; set; }
        public string IdUser { get; set; }
        public int TypeMouv { get; set; }
        public string PositionIni { get; set; }
        public string PositionFin { get; set; }
        public DateTime Date { get; set; }

        public User IdUserNavigation { get; set; }
        public HistoEquip SnNavigation { get; set; }
    }
}
