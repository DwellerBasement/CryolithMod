using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Cryolith.Content.Items.Materials.Frigidfrag;

namespace Cryolith.Content.VanRec
{
    public class FrostFeather : ModSystem
    {
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.IceFeather);
            recipe.AddIngredient(ModContent.ItemType<Frigidfrag>(), 30);
			recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}