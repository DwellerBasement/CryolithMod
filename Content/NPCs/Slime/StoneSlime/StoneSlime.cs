using Terraria;
using Terraria.ModLoader;                   
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader.Utilities;

namespace Cryolith.Content.NPCs.Slime.StoneSlime
{
    internal class StoneSlime : ModNPC
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
            npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 1, 3));
            npcLoot.Add(ItemDropRule.Common(ItemID.StoneBlock, 1, 1, 6));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            float baseChance = SpawnCondition.Overworld.Chance;

            if (spawnInfo.Player.ZoneNormalUnderground || spawnInfo.Player.ZoneNormalCaverns)
            {

                return baseChance * 1.07f;
            }

            return 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
        }
    }
}
