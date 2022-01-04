using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CigarReview.Domain.Cigars
{
    public interface ICigarRepository
    {
        Task<Cigar> Get(int id);
        Task<Cigar> Get(string name);
        Task<IEnumerable<Cigar>> Get();
        Task<IEnumerable<Cigar>> Get(Func<Cigar, bool> predicate);
        Task Delete(int id);
        Task AddOrUpdate(Cigar cigar);
    }
}
