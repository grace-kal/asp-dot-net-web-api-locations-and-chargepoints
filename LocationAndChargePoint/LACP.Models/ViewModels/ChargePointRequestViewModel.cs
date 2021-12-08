using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LACP.Models.ViewModels
{
    public class ChargePointRequestViewModel
    {
        public string LocationId { get; set; }
        public List<ChargePointViewModel> ChargePoints { get; set; }
    }
}
