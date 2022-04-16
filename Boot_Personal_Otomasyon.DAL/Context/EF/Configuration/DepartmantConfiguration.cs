using Boots_Personal_Otomasyon.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boots_Personal_Otomasyon.DAL.Context.EF.Configuration
{
    public class DepartmantConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(t => t.DepartmentName).HasMaxLength(255);

            builder.HasMany<Personal>(t => t.Personals).WithOne(t => t.Department).HasForeignKey(t => t.DepartmantId);
        }
    }
}
