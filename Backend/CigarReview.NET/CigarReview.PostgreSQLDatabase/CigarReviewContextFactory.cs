using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CigarReview.PostgreSQLDatabase
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
            builder.UseNpgsql(Configuration.GetConnectionString("postgre"));

            return new CigarReviewContext(builder.Options);
        }
    }
}
