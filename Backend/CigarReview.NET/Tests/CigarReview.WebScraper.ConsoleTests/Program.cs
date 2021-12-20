using System;
using System.Threading.Tasks;

namespace CigarReview.WebScraper.ConsoleTests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var scraper = new JrCigarsWebScraper();
            var brands = await scraper.GetBrands();
            //brands.Wait();
            foreach(var brand in brands)
            {
                Console.WriteLine(brand.Name);
            }
            var cigars = await scraper.Search("Romeo Julieta Reserve Churchill");
            //cigars.Wait();
        }
    }
}
