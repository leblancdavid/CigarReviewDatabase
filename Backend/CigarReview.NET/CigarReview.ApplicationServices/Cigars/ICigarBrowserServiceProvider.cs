using CigarReview.Domain.Cigars;

namespace CigarReview.ApplicationServices.Cigars
{
    public interface ICigarBrowserServiceProvider
    {
        ICigarBrowserService GetDefault();
    }
}
