 using Terraria.ModLoader;

namespace Cryolith.Content.Items.Accessories.FrostFist
{
    public class FrostFistsPlayer : ModPlayer
    {
        public bool frostFistsEquipped;

        public override void ResetEffects()
        {
            frostFistsEquipped = false; // Reset every tick
        }
    }
}
