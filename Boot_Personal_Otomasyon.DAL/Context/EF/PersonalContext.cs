using Boots_Personal_Otomasyon.DAL.Context.EF.Configuration;
using Boots_Personal_Otomasyon.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.DAL.Context.EF
{
    public class PersonalContext:DbContext
    {
        public PersonalContext(DbContextOptions<PersonalContext> options):base(options)
        {

        }
       
        public DbSet<UserAccount> UserAccount{ get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Department> Department { get; set; }

        private bool IsMigration = true;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (IsMigration)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-E7SV85T\\S2019; Database=PersonalDb; uid=sa; pwd=1;");
            }
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserAccountConfiguration());
            modelBuilder.ApplyConfiguration(new PersonalConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmantConfiguration());


            base.OnModelCreating(modelBuilder);
        }
    }
}
