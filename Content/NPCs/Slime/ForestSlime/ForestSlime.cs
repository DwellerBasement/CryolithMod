using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Cryolith.Content.Items.Materials.PlantFibre;

namespace Cryolith.Content.NPCs.Slime.ForestSlime
{
    internal class ForestSlime : ModNPC
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
            NPC.damage = 9;
            NPC.defense = 1;
            NPC.lifeMax = 20;

            AIType = NPCID.BlueSlime;
            AnimationType = NPCID.BlueSlime;

            Banner = Item.NPCtoBanner(NPCID.BlueSlime);
            BannerItem = Item.BannerToItem(Banner);
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlantFibre>(), 2, 1, 5));
            npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 1, 3));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            float baseChance = SpawnCondition.Overworld.Chance;

            if (spawnInfo.Player.ZoneForest)
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