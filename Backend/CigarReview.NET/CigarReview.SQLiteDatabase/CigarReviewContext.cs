using CigarReview.Domain.Cigars;
using Microsoft.EntityFrameworkCore;

namespace CigarReview.SQLiteDatabase
{
    public class CigarReviewContext : DbContext
    {
        public CigarReviewContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cigar> Cigars { get; set; }

        /*
        public CigarReviewContext()
        {

        }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
