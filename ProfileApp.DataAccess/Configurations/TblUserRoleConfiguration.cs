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
    public class TblUserRoleConfiguration : IEntityTypeConfiguration<TblUserRole>
    {
        public void Configure(EntityTypeBuilder<TblUserRole> builder)
        {
            builder.HasIndex(x => new
            {
                x.RoleId,
                x.UserId
            }).IsUnique();

            builder.HasOne(x => x.TblAppRole).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId);
            builder.HasOne(x => x.TblUser).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId);
        }
    }
}
