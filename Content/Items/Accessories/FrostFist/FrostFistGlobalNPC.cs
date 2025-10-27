using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Cryolith.Content.Items.Accessories.FrostFist
{
    public class FrostFistsGlobalNPC : GlobalNPC
    {
        public override void OnHitByItem(NPC npc, Player player, Item item, NPC.HitInfo hit, int damageDone)
        {
            if (player.GetModPlayer<FrostFistsPlayer>().frostFistsEquipped && item.DamageType == DamageClass.Melee)
            {
                npc.AddBuff(BuffID.Frostburn, 180); // 3 seconds
            }
        }

        public override void OnHitByProjectile(NPC npc, Projectile projectile, NPC.HitInfo hit, int damageDone)
        {
            if (projectile.owner >= 0 && projectile.DamageType == DamageClass.Melee)
            {
                Player player = Main.player[projectile.owner];
                if (player.GetModPlayer<FrostFistsPlayer>().frostFistsEquipped)
                {
                    npc.AddBuff(BuffID.Frostburn2, 180); // 3 seconds
                }
            }
        }
    }
}
