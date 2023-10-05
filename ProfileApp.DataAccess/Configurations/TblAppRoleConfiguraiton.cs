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
    public class TblAppRoleConfiguraiton : IEntityTypeConfiguration<TblAppRole>
    {
        public void Configure(EntityTypeBuilder<TblAppRole> builder)
        {
            builder.Property(x => x.Defination).IsRequired();
            builder.HasData(new TblAppRole[]
            {
                new TblAppRole()
                {
                    Defination = "Admin",
                    Id=1
                },
                new TblAppRole()
                {
                    Defination = "Member",
                    Id=2
                }
            });

        }
    }
}
