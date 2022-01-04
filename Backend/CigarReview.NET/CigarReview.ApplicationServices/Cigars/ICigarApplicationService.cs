using CigarReview.Domain.Cigars;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CigarReview.ApplicationServices.Cigars
{
    public interface ICigarApplicationService
    {
        Task<IEnumerable<Cigar>> Search(string keywords);
        Task<IEnumerable<Cigar>> GetCigars();
        Task<Cigar> GetCigar(int id);
        Task<Cigar> GetCigarByName(string name);
        Task<IEnumerable<Cigar>> GetCigars(Func<Cigar, bool> predicate);
        Task AddOrUpdateCigar(Cigar cigar);
    }
}
