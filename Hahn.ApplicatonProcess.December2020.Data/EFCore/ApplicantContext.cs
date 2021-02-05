using Hahn.ApplicatonProcess.December2020.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Data.EFCore
{
    public class ApplicantContext : DbContext
    {
        public ApplicantContext(DbContextOptions<ApplicantContext> options) : base(options)
        { }

        public DbSet<Applicant> Applicants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>(b =>
            {
                b.HasKey(a => a.ID);
                b.Property(c => c.ID).ValueGeneratedOnAdd();
            });
               
        }
    }
}
