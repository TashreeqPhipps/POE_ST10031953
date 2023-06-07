namespace POE_ST10031953
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var recipes = new List<Recipe>();

            AddRecipes(recipes);
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
            while (true)
            {
                try
                {
                    Console.WriteLine(string.Format("Please enter a number between 1 and {0} to remove", recipes.Count));
                    var selection = int.Parse(Console.ReadLine());
                    if (selection < recipes.Count)
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

                Console.WriteLine("Please enter the Name of the recipe: ");
                recipe = new Recipe(Console.ReadLine()!);


                GetAllIngredients(recipe);

                GetSteps(recipe);
                recipe.CalculateTotalCalories();
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

        private static void GetSteps(Recipe recipe)
        {
            int i = 1;
            while (true)
            {
                var step = new Step();
                step.Order = i;
                Console.WriteLine("Please enter the description of step {0}: ", step.Order);
                step.Description = Console.ReadLine();
                recipe.Steps.Add(step);
                i++;
            }
        }

        private static void GetAllIngredients(Recipe recipe)
        {
            while (true)
            {
                while (true)
                {
                    var ingrediant = new Ingrediant();
                    try
                    {
                        Console.WriteLine("Please enter Name of the ingredient: ");
                        ingrediant.Name = Console.ReadLine();
                        Console.WriteLine("Please enter the quantity of the ingredient:");
                        ingrediant.Quantity = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the unit of measure of the ingredient:");
                        ingrediant.UnitOfMeasurement = Console.ReadLine();
                        Console.WriteLine("Please enter the calories of the ingredient:");
                        ingrediant.Calories = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the food group of the ingredient:");
                        ingrediant.UnitOfMeasurement = Console.ReadLine();

                        recipe.Ingredients.Add(ingrediant);
                        Console.WriteLine("Is That all the ingredients? (Y/N)");
                        ingrediant.UnitOfMeasurement = Console.ReadLine();
                        if (GetYesOrNo())
                        {
                            break;
                        }

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

        private static bool GetYesOrNo()
        {
            return Console.ReadLine().ToLower().Trim().Equals("y");
        }
    }
}