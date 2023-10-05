using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProfileApp.DataAccess.Configurations;
using ProfileApp.Entity;


namespace ProfileApp.DataAccess.Context
{
    public class UserAppContext : DbContext
    {
        public UserAppContext(DbContextOptions<UserAppContext> options) : base(options)
        {

        }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UserAppContext>
        {
            public UserAppContext CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<UserAppContext>();
                var connectionString = @"server=104.247.167.130\MSSQLSERVER2022;database=followac_UserAppDb;user=followac_godswhip;password=Atilla_1994;TrustServerCertificate=True;Trusted_Connection=SSPI;Encrypt=true";
                //var connectionString = "Server =GODSWHIP\\SQLEXPRESS; Database=UserAppDb; ;TrustServerCertificate=True;Trusted_Connection=SSPI;Encrypt=false";
                builder.UseSqlServer(connectionString);
                return new UserAppContext(builder.Options);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TblActivationConfiguration());
            modelBuilder.ApplyConfiguration(new TblAppRoleConfiguraiton());
            modelBuilder.ApplyConfiguration(new TblStatusConfiguration());
            modelBuilder.ApplyConfiguration(new TblUserAccountConfiguration());
            modelBuilder.ApplyConfiguration(new TblUserConfiguration());
            modelBuilder.ApplyConfiguration(new TblUserRoleConfiguration());
        }

        public DbSet<TblActivation> TblActivations { get; set; }
        public DbSet<TblStatus> TblStatuss { get; set; }
        public DbSet<TblUser> TblUsers { get; set; }
        public DbSet<TblUserAccounts> TblUserAccountss { get; set; }

    }
}
