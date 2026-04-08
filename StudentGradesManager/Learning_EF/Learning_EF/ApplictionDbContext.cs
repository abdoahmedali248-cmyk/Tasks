using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Learning_EF
{
    public class ApplictionDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                @"Data Source=(localdb)\ProjectsV13;Initial Catalog=EFCore;Integrated Security=True"
            );

        }

        public DbSet<Employee> Employees {  get; set; }
    }
}
