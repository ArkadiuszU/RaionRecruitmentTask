using Microsoft.EntityFrameworkCore;
using RaionRecruitmentTaskDomain.Entities;

namespace RaionRecruitmentTaskInfrastructure
{
    internal class RaionRecruitmentTaskDbContext(DbContextOptions<RaionRecruitmentTaskDbContext> options) : DbContext(options)
    { 
        internal DbSet<Balance> Balances { get; set; }
        internal DbSet<AccountOwner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Balance>()
                .HasOne(b => b.Owner);

            modelBuilder.Entity<Balance>(
                eb =>
                {
                    eb.Property(b => b.Value).HasColumnType("MONEY");
                });
        }
    }
}
