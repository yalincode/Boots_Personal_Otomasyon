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
    public class PersonalConfiguration:IEntityTypeConfiguration<Personal>
    {
        public PersonalConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<Personal> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Twitter).HasMaxLength(500);
            builder.Property(t => t.Linkedln).HasMaxLength(500);
            builder.Property(t => t.Facebook).HasMaxLength(500);
            builder.Property(t => t.Address).HasMaxLength(2000);
            builder.Property(t => t.NameAndSurname).HasMaxLength(255).IsRequired();
            builder.Property(t => t.Email).HasMaxLength(255);
            builder.Property(t => t.Phone).HasMaxLength(50);

            
            
        }
    }
}
