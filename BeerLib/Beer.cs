namespace BeerLib
{
    public class Beer
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public double Abv { get; set; }

        public override string ToString()
            => $"{Id}, {Name}, {Abv}";

        public void ValidateId()
        {
            if (Id == null)
            {
                throw new ArgumentNullException("id is null");
            }
            if (Id < 0)
            {
                throw new ArgumentOutOfRangeException("id below 0");
            }
        }

        public void ValidateName()
        {
            if (Name == null)
            {
                throw new ArgumentNullException("name is null.");
            }
            if (Name.Length < 3)
            {
                throw new ArgumentException("name is less than three characters.");
            }
        }

        public void ValidateAlcoholByVolume()
        {
            if (Abv < 0 || Abv > 67)
            {
                throw new ArgumentOutOfRangeException("Alcohol volume is below 0 or above 67");
            }
        }

        public void Validate()
        {
            ValidateId();
            ValidateName();
            ValidateAlcoholByVolume();
        }
    }
}