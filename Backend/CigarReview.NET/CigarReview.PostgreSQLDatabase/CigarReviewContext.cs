using CigarReview.Domain.Cigars;
using Microsoft.EntityFrameworkCore;

namespace CigarReview.PostgreSQLDatabase
{
    public class CigarReviewContext : DbContext
    {
        public CigarReviewContext()
        {

        }

        public CigarReviewContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cigar> Cigars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
