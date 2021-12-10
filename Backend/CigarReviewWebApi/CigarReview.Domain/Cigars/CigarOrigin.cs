namespace CigarReview.Domain.Cigars
{
    public class CigarOrigin
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public CigarOrigin()
        {
            Name = "Unknown";
        }

        public CigarOrigin(string name)
        {
            Name = name;
        }
    }
}
