namespace POE_ST10031953
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingrediant> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
        public int TotalCalories { get; set; }

        private delegate void CaloryAlerter();

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingrediant>();
            Steps = new List<Step>();
        }

        internal void OutputString()
        {
            CaloryAlerter ca = new CaloryAlerter(CalorieAlert);
            ca();
            Console.WriteLine(Name.ToUpper());
            WriteLine();
            Console.WriteLine("INGREDIENTS");
            WriteLine();
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredients[i].OutputString(i + 1);
            }

            WriteLine();
            Console.WriteLine("STEPS");
            WriteLine();

            for (int i = 0; i < Steps.Count; i++)
            {
                Steps[i].OutputString();
            }

            WriteLine();

            Console.WriteLine("TOTAL CALORIES: {0}", TotalCalories);
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
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredients[i].Quantity = Ingredients[i].Quantity * scale;
            }
        }

        internal void ResetScaleCalculations(double scale)
        {
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredients[i].Quantity = Ingredients[i].Quantity / scale;
            }

        }

        public void CalculateTotalCalories()
        {
            for (int i = 0; i < Ingredients.Count; i++)
            {
                TotalCalories += Ingredients[i].Calories;
            }
        }

        internal void CalorieAlert()
        {
            if (TotalCalories > 300)
            {
                Console.WriteLine("The calories are over 300!!");
            }
        }
    }
}
