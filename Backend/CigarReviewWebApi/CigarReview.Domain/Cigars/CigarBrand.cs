namespace CigarReview.Domain.Cigars
{
    public class CigarBrand
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public CigarBrand()
        {
            Name = "Unknown";
        }

        public CigarBrand(string name)
        {
            Name = name;
        }
    }
}
