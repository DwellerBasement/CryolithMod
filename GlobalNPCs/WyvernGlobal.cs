using Cryolith.Content.Items.Placeables.Ore.Aero;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cryolith.GlobalNPCs
{
	public class WyvernGlobal : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (npc.type == NPCID.WyvernHead)
			{
				int myItemType = ModContent.ItemType<AeroOres>(); 
				npcLoot.Add(ItemDropRule.Common(myItemType, 1, 3, 6)); 
			}
		}
	}
}