using Cryolith.Content.Items.Placeables.Ore.Aero;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cryolith.GlobalNPCs
{
	public class HarpyGlobal : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (npc.type == NPCID.Harpy)
			{
				int myItemType = ModContent.ItemType<AeroOres>(); 
				npcLoot.Add(ItemDropRule.Common(myItemType, 2, 1, 2)); 
			}
		}
	}
}