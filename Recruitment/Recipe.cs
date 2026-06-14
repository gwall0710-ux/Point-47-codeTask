using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment
{
    public class Recipe : RecipeBase, IRecipe
    {
        public Recipe(string code, string description)
            : base(code, description) { }

        public override decimal TotalWeight => Ingredients.Sum(i => i.Quantity);

        public int CookLoss => (int)Math.Round((TotalWeight - CookedWeight) / TotalWeight * 100);

        public IEnumerable<Allergen> Allergens => Ingredients.SelectMany(i => i.Allergens).Distinct();

        public string IngredientsDeclaration =>
            Ingredients is null
            ? string.Empty
            : string.Join(", ",
                Ingredients
                    .OrderByDescending(i => i.Quantity)
                        .Select(i => i.Allergens.Any()
                            ? $"{i.Description} ({string.Join(", ", i.Allergens)})"
                            : i.Description));
    }
}
