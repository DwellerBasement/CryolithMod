using Cryolith.Content.Items.Accessories.CharmCryoBliz;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace Cryolith.Content.Items.Accessories.FrostFist
{
    internal class FrostFists : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 48;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 5);
            Item.rare = ItemRarityID.Pink;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.autoReuseGlove = true;
            player.GetModPlayer<FrostFistsPlayer>().frostFistsEquipped = true;
            player.meleeScaleGlove = true;
            player.kbGlove = true;
            player.GetAttackSpeed(DamageClass.Melee) += 0.12f;
            player.GetDamage(DamageClass.Melee) += 0.12f;

            if (Main.dayTime)
            {
                player.statDefense *= 1.1f;
                player.statLifeMax2 += 20;
                player.moveSpeed *= 1.03f;
            }
            else
            {
                player.moveSpeed *= 1.1f;
                player.statLifeMax2 += 20;
                player.statDefense *= 1.03f;
            }

        player.GetModPlayer<FrostFistsPlayer>().frostFistsEquipped = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FireGauntlet, 1);
            recipe.AddIngredient(ModContent.ItemType<CharmCryoBlizs>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
