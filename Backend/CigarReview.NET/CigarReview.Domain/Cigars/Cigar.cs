namespace CigarReview.Domain.Cigars
{
    public class Cigar
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public CigarBrand Brand { get; private set; }
        public decimal Length { get; private set; }
        public int RingSize { get; private set; }
        public CigarShape Shape { get; private set; }
        public CigarShade Shade { get; private set; }
        public TobaccoType Wrapper { get; private set; }
        public TobaccoType Binder { get; private set; }
        public TobaccoType Filler { get; private set; }
        public CigarOrigin Origin { get; private set; }
        public CigarStrength Strength { get; private set; }


        public Cigar(string name, string description, CigarBrand brand,
            decimal length, int ringSize,
            CigarShape shape, CigarShade shade,
            TobaccoType wrapper, TobaccoType binder, TobaccoType filler,
            CigarOrigin origin, CigarStrength strength)
        {
            Name = name;
            Description = description;
            Brand = brand;
            Length = length;
            RingSize = ringSize;
            Shape = shape;
            Shade = shade;
            Wrapper = wrapper;
            Binder = binder;
            Filler = filler;
            Origin = origin;
            Strength = strength;
        }

        private Cigar()
        {

        }

    }
}
