using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Cryolith.Content.Items.Materials.Frigidfrag;

namespace Cryolith.Content.VanRec
{
    public class FrostCore : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.FrostCore);
            recipe.AddIngredient(ModContent.ItemType<Frigidfrag>(), 15);
			recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}