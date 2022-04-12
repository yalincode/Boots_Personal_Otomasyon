using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boots_Personal_Otomasyon.DAL.Context.EF.Configuration
{
    using Entities;
    

    public class UserAccountConfiguration:IEntityTypeConfiguration<UserAccount>
    {
       
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.HasKey(t=>t.UserAccountId);
            builder.Property(t=>t.UserName).HasMaxLength(255).IsRequired();
            builder.Property(t=>t.Password).HasMaxLength(100).IsRequired();
            builder.Property(t=>t.FullName).HasMaxLength(255);
        }
    }
}
