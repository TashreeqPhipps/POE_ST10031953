namespace POE_ST10031953
{
    public class Ingrediant
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }

        public Ingrediant()
        {
            
        }

        public Ingrediant(string name, double quantity, string unitOfMeasurement)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Quantity = quantity;
            UnitOfMeasurement = unitOfMeasurement ?? throw new ArgumentNullException(nameof(unitOfMeasurement));
        }
    }
}
