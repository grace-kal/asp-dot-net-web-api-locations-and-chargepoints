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
    public class ChargePointViewModel
    {
        public string ChargePointId { get; set; }

        public string Status { get; set; }

        public string FloorLevel { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
