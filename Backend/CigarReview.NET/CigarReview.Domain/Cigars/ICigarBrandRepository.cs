using System.Collections.Generic;
using System.Threading.Tasks;

namespace CigarReview.Domain.Cigars
{
    public interface ICigarBrandRepository
    {
        Task<CigarBrand> Get(int id);
        Task<CigarBrand> Get(string name);
        Task<IEnumerable<CigarBrand>> Get();
        Task Delete(int id);
        Task AddOrUpdate(CigarBrand brand);
    }
}
