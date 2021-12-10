using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using CigarReview.Domain.Cigars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CigarReview.WebScraper
{
    public class JrCigarsWebScraper
    {
        private readonly string _searchUrl = "https://www.jrcigars.com/search?lang=en_US&q=";
        private readonly string _cigarBrandsUrl = "https://www.jrcigars.com/cigars/";

        public async Task<IEnumerable<CigarBrand>> GetBrands()
        {
            try
            {
                //Get HTML for the specified site stream 
                var doc = default(IHtmlDocument);
                using (var client = new HttpClient())
                {
                    using (var stream = await client.GetStreamAsync(new Uri(_cigarBrandsUrl)))
                    {
                        var parser = new HtmlParser();

                        doc = await parser.ParseDocumentAsync(stream);
                    }
                }

                var brands = new List<CigarBrand>();
                var brandLists = doc.GetElementsByClassName("brands-list-tabs");
                foreach(var list in brandLists)
                {
                    var rawBrands = list.GetElementsByClassName("link-bare bold");
                    foreach (var b in rawBrands)
                    {
                        var rawContent = b.TextContent.Trim();
                        brands.Add(new CigarBrand(rawContent));
                    }

                }

                return brands;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<CigarBrand>();
            }
        }

        public async Task<IEnumerable<Cigar>> Search(string keywords)
        {
            try
            {
                string searchStr = string.Join('+', keywords.Split(' '));
                //Get HTML for the specified site stream 
                var doc = default(IHtmlDocument);
                using (var client = new HttpClient())
                {
                    using (var stream = await client.GetStreamAsync(new Uri($"{_searchUrl}{searchStr}")))
                    {
                        var parser = new HtmlParser();

                        doc = await parser.ParseDocumentAsync(stream);
                    }
                }
                

                var elements = doc.GetElementsByClassName("product-detail product-tile item");


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<Cigar>();
        }

        private string GetMinMatchingString(string a, string b)
        {
            var a_split = a.Split(' ');
            var b_split = b.Split(' ');
            int i;
            for(i = 0; i < a_split.Length && i < b_split.Length; ++i)
            {
                if(a_split[i] != b_split[i])
                {
                    break;
                }
            }

            return string.Join(' ', a_split.Take(i));
        }
    }
}
