namespace POE_ST10031953
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Recipe recipe;
                int ingredientSize;
                int stepsSize;
                GetRecipeSizes(out recipe, out ingredientSize, out stepsSize);

                GetAllIngredients(recipe, ingredientSize);

                GetSteps(recipe, stepsSize);

                recipe.OutputString();
                Console.WriteLine("Would You like to scale up or down the recipe? (Y/N): ");
                if (GetYesOrNo())
                {
                    double scale = ScaleThisRecipe(recipe);
                    ResetRecipe(recipe, scale);
                }
                
                Console.WriteLine("Would you like to clear the recipe and start again? (Y/N)");
                if (GetYesOrNo())
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Thank you for using our App, goodbye!");
                    Task.Delay(5000).Wait();
                    Environment.Exit(0);
                }
                
            }
        }

        private static void ResetRecipe(Recipe recipe, double scale)
        {
            Console.WriteLine("Would you like to reset the values? (Y/N)");
            if (GetYesOrNo())
            {
                recipe.ResetScale(scale);
                Console.WriteLine("RECIPE SCALE RESET!");
                recipe.OutputString();
            }
        }

        private static double ScaleThisRecipe(Recipe recipe)
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

                recipe.ScaleRecipe(scale);
                recipe.OutputString();
                break;
            }

            return scale;
        }

        private static void GetSteps(Recipe recipe, int stepsSize)
        {
            for (int i = 0; i < stepsSize; i++)
            {
                var step = new Step();
                step.Order = i + 1;
                Console.WriteLine("Please enter the description of step {0}: ", step.Order);
                step.Description = Console.ReadLine();

                recipe.Steps[i] = step;
            }
        }

        private static void GetAllIngredients(Recipe recipe, int ingredientSize)
        {
            while (true)
            {
                for (int i = 0; i < ingredientSize; i++)
                {
                    var ingrediant = new Ingrediant();
                    try
                    {
                        Console.WriteLine("Please enter Name of ingredient: ");
                        ingrediant.Name = Console.ReadLine();
                        Console.WriteLine("Please enter the quantity of ingredient:");
                        ingrediant.Quantity = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the unit of measure of ingredient:");
                        ingrediant.UnitOfMeasurement = Console.ReadLine();
                        recipe.Ingredients[i] = ingrediant;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please enter a valid input");
                    }
                }
                Console.WriteLine("All Ingredients Entered!");
                break;
            }
        }

        private static void GetRecipeSizes(out Recipe recipe, out int ingredientSize, out int stepsSize)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter number of ingredients: ");
                    ingredientSize = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter number of Steps: ");
                    stepsSize = int.Parse(Console.ReadLine());
                    recipe = new Recipe(ingredientSize, stepsSize);
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid input");
                    continue;
                }

                break;
            }
        }

        private static bool GetYesOrNo()
        {
            return Console.ReadLine().ToLower().Trim().Equals("y");
        }
    }
}