namespace POE_ST10031953
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var recipes = new List<Recipe>();

            AddRecipes(recipes);
            // Display the list of recipes in alpahbetetical order
            // Can select and display (Add scale and delete too)
            // can exit from there
            while (true)
            {
                Console.Clear();
                Console.WriteLine("List of Recipies:");
                recipes.OrderBy(x => x.Name);
                for (int i = 0; i < recipes.Count; i++)
                {
                    Console.WriteLine(String.Format("{0}:\t{1}", i + 1, recipes[i].Name));
                }
                Console.WriteLine(@"Please enter a number to view or 'e' to exit or 'a' to add more recipes or 'r' to remove a recipe");

                int selection;
                var input = Console.ReadLine();
                var isNumber = int.TryParse(input, out selection);
                if (isNumber && (selection <= recipes.Count))
                {
                    recipes[selection].OutputString();
                    continue;
                }
                else if (input.Trim().ToLower().Equals("e"))
                {
                    Console.WriteLine("Thank you for using our App, goodbye!");
                    Delay();
                    Environment.Exit(0);
                }
                else if (input.Trim().ToLower().Equals("a"))
                {
                    AddRecipes(recipes);
                    continue;
                }
                else if (input.Trim().ToLower().Equals("r"))
                {
                    RemoveRecipe(recipes);
                    continue;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid input!");
                    Delay();
                    continue;
                }
            }
        }

        private static void RemoveRecipe(List<Recipe> recipes)
        {
            while(true)
            {
                try
                {
                    Console.WriteLine(string.Format("Please enter a number between 1 and {0} to remove", recipes.Count));
                    var selection = int.Parse(Console.ReadLine());
                    if (selection <= recipes.Count)
                    {
                        recipes.RemoveAt(selection - 1);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number in the range!");
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a valid input!");
                    continue;
                }

            }
        }

        private static void Delay()
        {
            Task.Delay(5000).Wait();
        }

        private static void AddRecipes(List<Recipe> recipes)
        {
            while (true)
            {
                Console.Clear();
                Recipe recipe;
                int ingredientSize;
                int stepsSize;
                GetRecipeSizes(out recipe, out ingredientSize, out stepsSize);

                GetAllIngredients(recipe, ingredientSize);

                GetSteps(recipe, stepsSize);
                recipes.Add(recipe);

                recipe.OutputString();

                Console.WriteLine("Would you like to clear the recipe and start again? (Y/N)");
                if (GetYesOrNo())
                {
                    recipes.RemoveAt(recipes.Count - 1);
                    continue;
                }
                Console.WriteLine("Would you like to add another recipe? (Y/N)");
                if (GetYesOrNo())
                {
                    continue;
                }
                break;
            }
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
                Console.WriteLine("Please enter the Name of the recipe: ");
                var name = Console.ReadLine();
                try
                {
                    Console.WriteLine("Please enter number of ingredients: ");
                    ingredientSize = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter number of Steps: ");
                    stepsSize = int.Parse(Console.ReadLine());
                    recipe = new Recipe(name!, ingredientSize, stepsSize);
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