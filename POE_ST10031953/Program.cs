namespace POE_ST10031953
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();
            var exit = false;

            while (!exit)
            {
                Console.WriteLine("Enter a command (add, scale, reset, clear, exit):");
                switch (Console.ReadLine().ToLower())
                {
                    case "add":
                        recipe.AddIngredient();
                        recipe.AddStep();
                        break;
                    case "scale":
                        recipe.Scale();
                        break;
                    case "reset":
                        recipe.Reset();
                        break;
                    case "clear":
                        recipe.Clear();
                        break;
                    case "exit":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Cammand");
                        break;
                }
            }
        }
    }
    }
}