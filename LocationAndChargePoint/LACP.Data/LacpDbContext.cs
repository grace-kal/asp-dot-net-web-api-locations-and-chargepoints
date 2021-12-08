using LACP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LACP.Data
{
    public class LacpDbContext : DbContext
    {
        public LacpDbContext(DbContextOptions<LacpDbContext> options) : base(options)
        {

        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ChargePoint> ChargePoints { get; set; }


    }
}
