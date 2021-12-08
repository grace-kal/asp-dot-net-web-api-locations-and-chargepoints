using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LACP.Models
{
    public class Location
    {
        public Location()
        {
            this.ChargePoints =new List<ChargePoint>();
        }

        [Key,
            Column(TypeName = "varchar"),
            MaxLength(39)]
        public string LocationId { get; set; }

        //only allowed values from the Type enum class
        [Required,
            MaxLength(45),
            Column(TypeName = "varchar")]
        
        public string Type { get; set; }

        [MaxLength(255), 
            Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        [Required, 
            MaxLength(45),
            Column(TypeName = "nvarchar")]
        public string Address { get; set; }

        [Required,
            MaxLength(45),
            Column(TypeName = "nvarchar")]
        public string City { get; set; }

        [Required,
            MaxLength(10),
            Column(TypeName = "nvarchar")]
        public string PostalCode { get; set; }

        [Required,
            MaxLength(45),
            Column(TypeName = "nvarchar")]
        public string Country { get; set; }

        [Required, 
            Column(TypeName = "datetime2")]
        public DateTime LastUpdated { get; set; }

        public virtual List<ChargePoint> ChargePoints { get; set; }
    }
}
