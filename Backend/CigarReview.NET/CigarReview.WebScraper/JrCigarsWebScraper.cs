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
    public class JrCigarsWebScraper : ICigarBrowserService
    {
        private readonly string _searchUrl = "https://www.jrcigars.com/search?lang=en_US&q=";
        private readonly string _cigarBrandsUrl = "https://www.jrcigars.com/cigars/";
        //TODO this should be a repo
        private List<CigarBrand> _brands = new List<CigarBrand>();

        public async Task<IEnumerable<CigarBrand>> GetBrands()
        {
            try
            {
                if(_brands.Any())
                {
                    return _brands;
                }

                //Get HTML for the specified site stream 
                var doc = default(IHtmlDocument);
                using (var client = new HttpClient())
                {
                    using (var stream = await client.GetStreamAsync(new Uri(_cigarBrandsUrl)).ConfigureAwait(false))
                    {
                        var parser = new HtmlParser();

                        doc = await parser.ParseDocumentAsync(stream);
                    }
                }

                _brands = new List<CigarBrand>();
                var brandLists = doc.GetElementsByClassName("brands-list-tabs");
                foreach(var list in brandLists)
                {
                    var rawBrands = list.GetElementsByClassName("link-bare bold");
                    foreach (var b in rawBrands)
                    {
                        var rawContent = b.TextContent.Trim();
                        _brands.Add(new CigarBrand(rawContent));
                    }

                }

                return _brands;

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
                var cigars = new List<Cigar>();
                string searchStr = string.Join('+', keywords.Split(' '));
                //Get HTML for the specified site stream 
                var doc = default(IHtmlDocument);
                using (var client = new HttpClient())
                {
                    using (var stream = await client.GetStreamAsync(new Uri($"{_searchUrl}{searchStr}")).ConfigureAwait(false))
                    {
                        var parser = new HtmlParser();

                        doc = await parser.ParseDocumentAsync(stream);
                    }
                }
                

                var foundMatches = doc.GetElementsByClassName("product-detail product-tile item");

                foreach(var match in foundMatches)
                {
                    if (!match.HasAttribute("data-itemid"))
                        continue;

                    var link = match.GetElementsByClassName("product-tile-link").FirstOrDefault();
                    if (link == null)
                        continue;

                    var cigar = await GetCigarFromLink($"https://www.jrcigars.com{link.GetAttribute("href")}");
                    if (cigar == null)
                        continue;

                    cigars.Add(cigar);
                }

                return cigars;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Cigar>();
            }

        }

        private async Task<Cigar> GetCigarFromLink(string link)
        {
            var doc = default(IHtmlDocument);
            using (var client = new HttpClient())
            {
                using (var stream = await client.GetStreamAsync(new Uri(link)).ConfigureAwait(false))
                {
                    var parser = new HtmlParser();

                    doc = await parser.ParseDocumentAsync(stream);
                }
            }

            var brandName = doc.GetElementById("bc_2")?
                    .GetElementsByClassName("breadcrumb link-bare").FirstOrDefault()?
                    .FirstElementChild?.TextContent;

            CigarBrand brand = new CigarBrand("Unknown");
            if(!string.IsNullOrEmpty(brandName))
            {
                brand = new CigarBrand(brandName);
            }

            var pageItem = doc.GetElementsByClassName("page-item").FirstOrDefault();
            if(pageItem == null)
            {
                return null;
            }

            var name = pageItem.FirstElementChild?.TextContent;
            var description = pageItem.GetElementsByClassName("item-description").FirstOrDefault()?.TextContent;

            var detailsElement = doc.GetElementsByClassName("cigar-details").FirstOrDefault();
            if (detailsElement == null)
            {
                return null;
            }
            var properties = detailsElement.GetElementsByClassName("form-control-static").ToList();
            if(properties.Count < 9)
            {
                return null;
            }

            decimal length = 0.0m;
            int ring = 0;
            if (!decimal.TryParse(properties[0].FirstElementChild?.TextContent, out length) ||
                !int.TryParse(properties[1].FirstElementChild?.TextContent, out ring))
                return null;

            var shape = new CigarShape(properties[2].FirstElementChild?.TextContent);
            var wrapper = new TobaccoType(properties[3].FirstElementChild?.TextContent);
            var binder = new TobaccoType(properties[4].FirstElementChild?.TextContent);
            var filler = new TobaccoType(properties[5].FirstElementChild?.TextContent);
            var origin = new CigarOrigin(properties[6].FirstElementChild?.TextContent);
            var strength = new CigarStrength(properties[7].FirstElementChild?.TextContent);
            var wrapperShade = new CigarShade(properties[8].FirstElementChild?.TextContent);

            return new Cigar(name, description, brand, length, ring, shape, wrapperShade, wrapper, binder, filler, origin, strength);
        }
    }
}
