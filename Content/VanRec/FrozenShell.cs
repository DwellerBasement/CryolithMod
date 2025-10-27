using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Cryolith.Content.Items.Materials.Frigidfrag;

namespace Cryolith.Content.VanRec
{
    public class FrozenShell : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.FrozenTurtleShell);
            recipe.AddIngredient(ModContent.ItemType<Frigidfrag>(), 210);
			recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}