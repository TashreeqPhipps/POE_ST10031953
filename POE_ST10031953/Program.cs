namespace POE_ST10031953
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ask user for number of ingrediants
            // Each must have: Name, Quantity, unit of measurement
            // Once all ingrediants have been entered, add steps
            // Each step has a desciption (and a order number)
            // Ask for scale (max 3 origional 1) then display
            // in Display have a reset quanitities? redoes display if input provided
            // in display, has a clear

            Recipe recipe;
            int ingredientSize;
            int stepsSize;
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

            while(true)
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

            for (int i = 0; i < stepsSize; i++)
            {
                var step = new Step();
                step.Order = i + 1;
                Console.WriteLine("Please enter the description of step {0}: ", step.Order);
                step.Description = Console.ReadLine();

                recipe.Steps[i] = step;
            }

            recipe.OutputString();
            

            //Console.WriteLine("Enter a command (add, scale, reset, clear, exit):");
            //switch (Console.ReadLine().ToLower())
            //{
            //    case "add":
            //        recipe.AddIngredient();
            //        recipe.AddStep();
            //        break;
            //    case "scale":
            //        recipe.Scale();
            //        break;
            //    case "reset":
            //        recipe.Reset();
            //        break;
            //    case "clear":
            //        recipe.Clear();
            //        break;
            //    case "exit":
            //        exit = true;
            //        break;
            //    default:
            //        Console.WriteLine("Invalid Cammand");
            //        break;
            //}

        }
    }
}