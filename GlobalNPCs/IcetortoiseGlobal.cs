using Cryolith.Content.Items.Materials.Frigidfrag;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Cryolith.GlobalNPCs
{
	public class IcetortoiseGlobal : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (npc.type == NPCID.IceTortoise)
			{
				int myItemType = ModContent.ItemType<Frigidfrag>(); 
				npcLoot.Add(ItemDropRule.Common(myItemType, 3)); 
			}
		}
	}
}