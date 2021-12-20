namespace CigarReview.Domain.Cigars
{
    public class CigarStrength
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Value { get; private set; }

        public CigarStrength()
        {
            Name = "Unknown";
        }

        public CigarStrength(string name)
        {
            Name = name;
        }

        public CigarStrength(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
