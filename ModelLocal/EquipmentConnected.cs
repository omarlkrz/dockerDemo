using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi10.ModelLocal
{
    public class EquipmentConnected
    {
        public string ModelDetected { get; set; }
        public string vendorDetected { get; set; }
        public string NomPost { get; set; }
        public string SN { get; set; }
        public string ModelName { get; set; }
        public string VendorName { get; set; }
        public string Type { get; set; }
        public bool? SNDetected { get; set; }
        public bool? exist = true;

    }
}
