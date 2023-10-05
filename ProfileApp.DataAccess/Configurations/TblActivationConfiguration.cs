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
    public class TblActivationConfiguration : IEntityTypeConfiguration<TblActivation>
    {
        public void Configure(EntityTypeBuilder<TblActivation> builder)
        {
            builder.Property(x => x.ActivationCode).IsRequired();
            builder.HasOne(x => x.Status).WithMany(x => x.TblActivation).HasForeignKey(x => x.StatusId);
        }
    }
}
