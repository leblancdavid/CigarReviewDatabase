namespace CigarReview.Domain.Cigars
{
    public class CigarShade
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public CigarShade()
        {
            Name = "Unknown";
        }

        public CigarShade(string name)
        {
            Name = name;
        }
    }
}
