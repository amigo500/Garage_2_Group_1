#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage_2_Group_1.Models;

namespace Garage_2_Group_1.Data
{
    public class Garage_2_Group_1Context : DbContext
    {
        public Garage_2_Group_1Context (DbContextOptions<Garage_2_Group_1Context> options)
            : base(options)
        {
        }

        public DbSet<Garage_2_Group_1.Models.Vehicle> Vehicle { get; set; }
    }
}
