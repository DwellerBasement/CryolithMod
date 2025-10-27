 using Terraria.ModLoader;

namespace Cryolith.Content.Items.Accessories.ArmEqui
{
    public class ArmEquiPlayer : ModPlayer
    {
        public bool ArmEquiEquipped;

        public override void ResetEffects()
        {
            ArmEquiEquipped = false; // Reset every tick
        }
    }
}
