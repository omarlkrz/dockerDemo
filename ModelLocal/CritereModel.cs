using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi10.ModelLocal
{
    public class CritereModel
    {
        public int IdTypeDev { get; set; }
        public int CodeVendor { get; set; }
        public int SNDetectable { get; set; }
        public int ModelDetectable { get; set; }
        public string Propriete { get; set; }
        public string Description { get; set; }
    }
}
