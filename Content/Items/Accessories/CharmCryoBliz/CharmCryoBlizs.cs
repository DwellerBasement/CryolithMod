using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace Cryolith.Content.Items.Accessories.CharmCryoBliz
{
    internal class CharmCryoBlizs : ModItem
    {

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults() 
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
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
        }
    }
}



    

