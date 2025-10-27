using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Cryolith.Content.Items.Materials.PlantFibre;

namespace Cryolith.Content.NPCs.Slime.KelpySlime
{
    internal class KelpySlime : ModNPC
    {
        public override void SetStaticDefaults()
        {

            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.BlueSlime];


            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Skeleton;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.BlueSlime);
            NPC.damage = 15;
            NPC.defense = 3;
            NPC.lifeMax = 27;

            AIType = NPCID.BlueSlime;
            AnimationType = NPCID.BlueSlime;

            Banner = Item.NPCtoBanner(NPCID.BlueSlime);
            BannerItem = Item.BannerToItem(Banner);
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlantFibre>(), 1, 3, 5));
            npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 2, 1, 4));
            npcLoot.Add(ItemDropRule.Common(ItemID.PinkJellyfish, 50, 1, 2));
            npcLoot.Add(ItemDropRule.Common(ItemID.Coral, 28, 1, 3));
            npcLoot.Add(ItemDropRule.Common(ItemID.Starfish, 24, 1, 2));   
			npcLoot.Add(ItemDropRule.Common(ItemID.LimeKelp, 12, 1, 2));   
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            // Base world spawn chance in the overworld
            float baseChance = SpawnCondition.Overworld.Chance;

            if (spawnInfo.Player.ZoneBeach)
            {

                return baseChance * 1.2f;
            }

            return 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
        }
    }
}