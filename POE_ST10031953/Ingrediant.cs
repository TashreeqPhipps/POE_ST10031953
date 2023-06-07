namespace POE_ST10031953
{
    public class Ingrediant
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        public Ingrediant()
        {
        }

        public void OutputString(int count)
        {
            Console.WriteLine("{0}:\t{1} {2} of {3}",
            count,
            Quantity,
            UnitOfMeasurement,
            Name);
        }
    }
}
