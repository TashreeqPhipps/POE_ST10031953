namespace POE_ST10031953
{
    public class Recipe
    {
        public string Name { get; set; }
        public Ingrediant[] Ingredients { get; set; }
        public Step[] Steps { get; set; }

        public Recipe(string name, int ingrediantsSize, int stepsSize)
        {
            Name = name;
            Ingredients = new Ingrediant[ingrediantsSize];
            Steps = new Step[stepsSize];
        }

        internal void OutputString()
        {
            Console.WriteLine(Name.ToUpper());
            WriteLine();
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

            Console.WriteLine("Would You like to scale up or down the recipe? (Y/N): ");
            if (GetYesOrNo())
            {
                double scale = ScaleRecipe();
                ResetRecipe(scale);
            }

        }

        private double ScaleRecipe()
        {
            double scale;
            while (true)
            {
                try
                {
                    Console.WriteLine("What would you like to scale it to? (0.5 is half, 2 is double and 3 is triple): ");
                    scale = double.Parse(Console.ReadLine().Replace(',', '.'));
                }
                catch
                {
                    Console.WriteLine("Please enter a valid number");
                    continue;
                }

                ScaleRecipeCalculations(scale);
                OutputString();
                break;
            }

            return scale;
        }


        private void ResetRecipe(double scale)
        {
            Console.WriteLine("Would you like to reset the values? (Y/N)");
            if (GetYesOrNo())
            {
                ResetScaleCalculations(scale);
                Console.WriteLine("RECIPE SCALE RESET!");
                OutputString();
            }
        }

        private bool GetYesOrNo()
        {
            return Console.ReadLine().ToLower().Trim().Equals("y");
        }

        private static void WriteLine()
        {
            Console.WriteLine("--------------------------------------------------------------");
        }

        internal void ScaleRecipeCalculations(double scale)
        {
            for (int i = 0; i < Ingredients.Length; i++)
            {
                Ingredients[i].Quantity = Ingredients[i].Quantity * scale;
            }
        }

        internal void ResetScaleCalculations(double scale)
        {
            for (int i = 0; i < Ingredients.Length; i++)
            {
                Ingredients[i].Quantity = Ingredients[i].Quantity / scale;
            }

        }
    }
}
