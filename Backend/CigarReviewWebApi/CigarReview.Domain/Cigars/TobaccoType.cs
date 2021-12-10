namespace CigarReview.Domain.Cigars
{
    public class TobaccoType
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public TobaccoType()
        {
            Name = "Unknown";
        }

        public TobaccoType(string name)
        {
            Name = name;
        }
    }
}
