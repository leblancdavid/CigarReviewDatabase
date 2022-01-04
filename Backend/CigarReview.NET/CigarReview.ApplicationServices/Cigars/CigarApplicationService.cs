using CigarReview.Domain.Cigars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CigarReview.ApplicationServices.Cigars
{
    public class CigarApplicationService : ICigarApplicationService
    {
        private readonly ICigarBrowserServiceProvider cigarBrowserServiceProvider;
        private readonly ICigarRepository cigarRepository;

        public CigarApplicationService(ICigarBrowserServiceProvider cigarBrowserServiceProvider,
            ICigarRepository cigarRepository)
        {
            this.cigarBrowserServiceProvider = cigarBrowserServiceProvider;
            this.cigarRepository = cigarRepository;
        }
        public async Task AddOrUpdateCigar(Cigar cigar)
        {
            await cigarRepository.AddOrUpdate(cigar);
        }

        public async Task<Cigar> GetCigar(int id)
        {
            return await cigarRepository.Get(id);
        }

        public async Task<Cigar> GetCigarByName(string name)
        {
            return await cigarRepository.Get(name);
        }

        public async Task<IEnumerable<Cigar>> GetCigars()
        {
            return await cigarRepository.Get();
        }

        public async Task<IEnumerable<Cigar>> GetCigars(Func<Cigar, bool> predicate)
        {
            return await cigarRepository.Get(predicate);
        }

        public async Task<IEnumerable<Cigar>> Search(string keywords)
        {
            var browser = cigarBrowserServiceProvider.GetDefault();
            var cigars = await browser.Search(keywords);

            foreach(var cigar in cigars)
            {
                await cigarRepository.AddOrUpdate(cigar);
            }

            return cigars;
        }
    }
}
