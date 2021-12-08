using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LACP.Models
{
    public class ChargePoint
    {
        [Key, 
            Column(TypeName = "varchar"), 
            MaxLength(39)]
        public string ChargePointId { get; set; }

        [Required,
            MaxLength(39), 
            Column(TypeName = "varchar")]
        //only allowed values from the Status enum class
        public string Status { get; set; }

        [MaxLength(4),
            Column(TypeName = "varchar")]
        public string FloorLevel { get; set; }

        [Required,
            Column(TypeName = "datetime2")]
        public DateTime LastUpdated { get; set; }

        [ForeignKey("Location")]
        public string LocationId { get; set; }
        public virtual Location Location { get; set; }


    }
}
