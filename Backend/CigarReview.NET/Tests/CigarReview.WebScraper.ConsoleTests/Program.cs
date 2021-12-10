using System;

namespace CigarReview.WebScraper.ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var scraper = new JrCigarsWebScraper();
            var brands = scraper.GetBrands();
            brands.Wait();
            foreach(var brand in brands.Result)
            {
                Console.WriteLine(brand.Name);
            }
            var cigars = scraper.Search("Romeo Julieta Reserve Churchill");
            cigars.Wait();
        }
    }
}
