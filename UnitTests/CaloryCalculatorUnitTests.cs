using POE_ST10031953;

namespace UnitTests
{
    [TestClass]
    public class CaloryCalculatorUnitTests
    {
        [TestMethod]
        public void TotalCaloryReturnsValidNumber()
        {
            // Given
            Recipe recipe = new Recipe("Tester");
            int calories = 0;
            for (int i = 0; i < 10; i++)
            {
                var testIngrediant = new Ingrediant();
                Random rnd = new Random();
                int tempCalories = rnd.Next(1, 50);
                testIngrediant.Calories = tempCalories;
                calories += tempCalories;
                recipe.Ingredients.Add(testIngrediant);
            }

            // When
            recipe.CalculateTotalCalories();

            // Then
            Assert.AreEqual(recipe.TotalCalories, calories);
        }
    }
}