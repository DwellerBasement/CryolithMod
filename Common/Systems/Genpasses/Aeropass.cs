using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Generation;
using System.Collections.Generic;
using Terraria.WorldBuilding;
using Terraria.IO;
using Terraria.Localization;
using Cryolith.Content.Tiles.Aero;

namespace Cryolith.Systems.Genpasses
{
	// 2. Use a unique name for the GenPass container to avoid conflicts with the pass class
	public class AeropassSystem : ModSystem
	{
		// 3. Localization message for the pass
		public static LocalizedText AeropassMessage { get; private set; }

		public override void SetStaticDefaults() {
			AeropassMessage = Language.GetOrRegister(Mod.GetLocalizationKey($"WorldGen.{nameof(AeropassMessage)}"));
		}

		// 4. Register our world generation pass in the proper place
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight) {
			int shiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (shiniesIndex != -1) {
				tasks.Insert(shiniesIndex + 1, new AeropassGenPass("World Gen Tutorial Ores (AeroOre)", 100f));
			}
		}
	}

	// 7. Custom GenPass class (distinct from the system class)
	public class AeropassGenPass : GenPass
	{
		public AeropassGenPass(string name, float loadWeight) : base(name, loadWeight) {
		}

		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration) {
			// 9. Progress message for the user
			progress.Message = Cryolith.Systems.Genpasses.AeropassSystem.AeropassMessage.Value;

			// 10. Determine how many attempts to spawn
			int attempts = (int)((Main.maxTilesX * Main.maxTilesY) * 5E-05); // ~0.00005 per tile
			int maxDepth = (int)GenVars.worldSurfaceLow;

			for (int k = 0; k < attempts; k++) {
				// 12. Random position across the world (x) and from surface to bottom (y)
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next(maxDepth, Main.maxTilesY);

				// 13. Spawn a blob of AeroOre (replace with your tile type if needed)
				int width = WorldGen.genRand.Next(6, 9);
				int height = WorldGen.genRand.Next(2, 6);

				int aeroOreTileType = ModContent.TileType<AeroOre>(); 
				WorldGen.TileRunner(x, y, width, height, aeroOreTileType);
			}
		}
	}
}