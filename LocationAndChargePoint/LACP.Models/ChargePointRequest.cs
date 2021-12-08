using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LACP.Models
{
    public class ChargePointRequest
    {
        //this is a model not saved in the db
        public string LocationId { get; set; }
        public List<ChargePoint> ChargePoints { get; set; }
    }
}
