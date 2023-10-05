using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfileApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.DataAccess.Configurations
{
    public class TblUserConfiguration : IEntityTypeConfiguration<TblUser>
    {
        public void Configure(EntityTypeBuilder<TblUser> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.UserNamGuidId).IsRequired();
            builder.Property(x => x.MailAdress).IsRequired();

            builder.HasOne(x => x.Status).WithMany(x => x.TblUser).HasForeignKey(x => x.StatusId);
            
        }
    }
}
