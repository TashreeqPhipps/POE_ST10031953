namespace POE_ST10031953
{
    public class Recipe
    {
        public Ingrediant[] Ingredients { get; set; }
        public Step[] Steps { get; set; }

        public Recipe()
        {
            
        }

        public Recipe(int ingrediantsSize, int stepsSize)
        {
            Ingredients = new Ingrediant[ingrediantsSize];
            Steps = new Step[stepsSize];
        }

        internal void OutputString()
        {
            Console.WriteLine("INGREDIENTS");
            WriteLine();
            for (int i = 0; i < Ingredients.Length; i++)
            {
                Console.WriteLine("{0}:\t{1} {2} of {3}",
                    i+1,
                    Ingredients[i].Quantity,
                    Ingredients[i].UnitOfMeasurement,
                    Ingredients[i].Name);
            }

            WriteLine();
            Console.WriteLine("STEPS");
            WriteLine();

            for (int i = 0; i < Steps.Length; i++)
            {
                Console.WriteLine("Step {0}:\t{1}",
                    Steps[i].Order,
                    Steps[i].Description);
            }

            WriteLine();
        }

        private static void WriteLine()
        {
            Console.WriteLine("--------------------------------------------------------------");
        }
    }
}
