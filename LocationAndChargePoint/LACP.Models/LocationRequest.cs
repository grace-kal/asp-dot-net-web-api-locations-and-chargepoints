using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LACP.Models
{
    public class LocationRequest
    {
        //this is a viewmodel not saved in the db
        public string LocationId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
