namespace CigarReview.Domain.Cigars
{
    public class CigarShape
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public CigarShape()
        {
            Name = "Unknown";
        }

        public CigarShape(string name)
        {
            Name = name;
        }
    }
}
