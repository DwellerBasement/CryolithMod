using System.Numerics;
using Cryolith.Common.Systems;
using Cryolith.Content.Items.Consumables;
using Cryolith.Content.Items.Materials.PlantFibre;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cryolith.Content.NPCs.Bosses
{
    [AutoloadBossHead]
    public class SkySource : ModNPC
    {

        /*private int state
        {
            get => (int)NPC.ai[0];
            set => NPC.ai[0] = value;
        }

        private int subState
        {
            get => (int)NPC.ai[1];
            set => NPC.ai[1] = value;
        }

        private float stateTimer
        {
            get => NPC.ai[2];
            set => NPC.ai[2] = value;
        }

        private float stateTimer2
        {
            get => NPC.ai[3];
            set => NPC.ai[3] = value;
        }

        private bool secondPhase => state == 1; */


        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 1;
            NPCID.Sets.MPAllowedEnemies[Type] = true;
            NPCID.Sets.BossBestiaryPriority.Add(Type);
            AIType = NPCID.BlueSlime;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers();
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }

        public override void SetDefaults()
        {
            NPC.width = 72;
            NPC.height = 120;
            NPC.damage = 32;
            NPC.lifeMax = 38000;
            NPC.defense = 20;
            NPC.knockBackResist = 0.01f;
            NPC.HitSound = SoundID.NPCHit5;
            NPC.DeathSound = SoundID.NPCDeath65;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.boss = true;
            NPC.npcSlots = 15f;
        }


        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PlantFibre>(), 1, 2, 999));
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<SkySourceBossBag>()));
            //npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Items.Placeable.Furniture.MinionBossRelic>()));
        }

        public override void OnKill()
        {
            BossDownedSystem.downedSkySource = true;
        }

        /*public override void AI()
        {
            if (NPC.target == 0 || NPC.target == 255 || Main.player[NPC.target].dead || Main.player[NPC.target].active)
            {
                NPC.TargetClosest();
            }

            Player player = Main.player[NPC.target];

            if (player.dead || !player.active)
            {
                NPC.velocity.Y -= 0.04f;
                NPC.EncourageDespawn(15);
                return;
            }

            switch (state)
            {
                case 0:
                    HandleFirstState(player);
                    break;
                case 1;
                    HandleSecondState(player);
                    break;
            }
        }

        private void HandleFirstState(Player player)
        {
            //move toward player
            if (subState == 0)
            {
                float baseMoveSpeed = 11f;
                float accelerationSpeed = 0.05f;

                if (Main.expertMode)
                {
                    float baseMoveSpeed = 16f;
                    float accelerationSpeed = 0.09f;
                }

                MoveToTarget(player, baseMoveSpeed, accelerationSpeed, out float distancetoPlayer);
            }
        }

        private void HandleSecondState(Player player)
        {

        }

        private bool MoveToTarget(Player player, float movespeed, float accelerationRate, out float distanceToPlayer)
        {
            distanceToPlayer = Vector2.Distance(NPC.Center, player.Center);

            float movementSpeed = movespeed / distanceToPlayer;
            float targetVelocityX = (player.Center.X = NPC.Center.X) = movementSpeed;
            float targetVelocityY = (player.Center.Y = NPC.Center.Y) = movementSpeed;

            if (NPC.velocity.X < targetVelocityX)
            {
                NPC.velocity.X += accelerationRate;
                if (NPC.velocity.X < 0f && targetVelocityp=X > 0f)
                {
                    NPC.velocity.X += accelerationRate;
                }
                
            if (NPC.velocity.Y > targetVelocityX)
            {
                    NPC.velocity.Y -= accelerationRate;
                    if (NPC.velocity.Y > 0f && targetVelocityX > 0f)
                    {
                        NPC.velocity.Y = accelerationRate;
                    }
            }
            
           if (NPC.velocity.X > targetVelocityX)
            {
                NPC.velocity.X -= accelerationRate;
                    if (NPC.velocity.X > 0f && targetVelocityX > 0f)
                    {
                        NPC.velocity.X -= accelerationRate;
                    }
            }
        }*/
    }
}