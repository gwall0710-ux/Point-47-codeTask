using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Tests
{
    [TestFixture]
    public class RecipeTests
    {
        [Test]
        public void Recipe_ShouldCorrectlyReturnDescription()
        {
            Recipe recipe = RecipeTestData.GetVegetableSoupRecipe();

            Assert.That(recipe.Description, Is.EqualTo("Vegetable Soup"));
        }

        [Test]
        [TestCase(100, ExpectedResult = 0)]
        [TestCase(75, ExpectedResult = 25)]
        [TestCase(0, ExpectedResult = 100)]
        [TestCase(33.33, ExpectedResult = 67)]
        [TestCase(200, ExpectedResult = -100)]
        public decimal Recipe_ShouldCorrectlyCalculateCookLoss(decimal cookedWeight)
        {
            IRecipe recipe = (IRecipe)RecipeTestData.GetBeefPieRecipe();
            recipe.CookedWeight = cookedWeight;
            return recipe.CookLoss;
        }

        [Test]
        public void Recipe_ShouldCorrectlyCalculateTotalWeight()
        {
            Recipe recipe = RecipeTestData.GetPancakeRecipe();

            Assert.That(recipe.TotalWeight, Is.EqualTo(200));
        }

        [Test]
        public void Recipe_ShouldCorrectlyReturnAllergens()
        {
            Recipe recipe = RecipeTestData.GetPancakeRecipe();
            var allergens = recipe.Allergens.ToList();

            Assert.That(allergens.Count, Is.EqualTo(2));
            Assert.That(allergens, Does.Contain(Allergen.Egg));
            Assert.That(allergens, Does.Contain(Allergen.Milk));
        }

        [Test]
        public void Recipe_ShouldCorrectlyReturnIngredientsDeclaration()
        {
            Recipe recipe = RecipeTestData.GetPancakeRecipe();
            string expectedDeclaration = "Flour, Milk (Milk), Eggs (Egg)";
            Assert.That(recipe.IngredientsDeclaration, Is.EqualTo(expectedDeclaration));
        }
    }
}
