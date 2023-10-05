using Microsoft.EntityFrameworkCore;
using ProfileApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileApp.DataAccess.Configurations
{
    public class TblUserAccountConfiguration : IEntityTypeConfiguration<TblUserAccounts>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TblUserAccounts> builder)
        {
            builder.Property(x => x.AccountName).IsRequired();
            builder.Property(x => x.AccountUrl).IsRequired();

            builder.HasOne(x => x.TblUser).WithMany(x => x.UserAccounts).HasForeignKey(x => x.UserId);

        }
    }
}
