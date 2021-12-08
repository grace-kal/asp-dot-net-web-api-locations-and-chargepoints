using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LACP.Models.ViewModels
{
    public class LocationViewModel
    {
        public LocationViewModel()
        {
            this.ChargePoints = new List<ChargePointViewModel>();
        }
        public string LocationId { get; set; }
        //only allowed values from the Type enum class
        public string Type { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<ChargePointViewModel> ChargePoints { get; set; }
    }
}
