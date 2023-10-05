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
    public class TblStatusConfiguration : IEntityTypeConfiguration<TblStatus>
    {
        public void Configure(EntityTypeBuilder<TblStatus> builder)
        {
            builder.Property(x => x.StatusName).IsRequired();
            
        }
    }
}
