using Cryolith.Content.Items.Materials.PlantFibre;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cryolith.GlobalNPCs
{
	public class ZombieGlobal : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (npc.type == NPCID.Zombie)
			{
				int myItemType = ModContent.ItemType<PlantFibre>(); 
				npcLoot.Add(ItemDropRule.Common(myItemType, 2, 0, 3)); 
			}
		}
	}
}