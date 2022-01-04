using System.Collections.Generic;
using System.Threading.Tasks;

namespace CigarReview.Domain.Cigars
{
    public interface ICigarBrowserService
    {
        Task<IEnumerable<CigarBrand>> GetBrands();
        Task<IEnumerable<Cigar>> Search(string keywords);
    }
}
