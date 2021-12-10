using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CigarReview.SQLiteDatabase
{
    class CigarReviewContextFactory : IDesignTimeDbContextFactory<CigarReviewContext>
    {
        public CigarReviewContextFactory()
        {
        }

        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("dbsettings.json")
            .Build();

        public CigarReviewContext CreateDbContext(string[] args)
        {

            var builder = new DbContextOptionsBuilder<CigarReviewContext>();
            builder.UseSqlite(Configuration.GetConnectionString("CigarReviewDbDesignTime"));

            return new CigarReviewContext(builder.Options);
        }
    }
}
