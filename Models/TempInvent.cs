using System;
using System.Collections.Generic;

namespace WebApi10.Models
{
    public partial class TempInvent
    {
        public int Id { get; set; }
        public string ModelDetected { get; set; }
        public string VendorDetected { get; set; }
        public string NomPost { get; set; }
        public string Sn { get; set; }
        public string ModelName { get; set; }
        public string VendorName { get; set; }
        public string Type { get; set; }
    }
}
