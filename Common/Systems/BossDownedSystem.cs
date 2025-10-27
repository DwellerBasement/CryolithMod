using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Cryolith.Common.Systems
{
    public class BossDownedSystem : ModSystem
    {
        public static bool downedSkySource = false;
        public override void ClearWorld()
        {
            downedSkySource = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag["downedSkySource"] = downedSkySource;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            downedSkySource = tag.GetBool("downedSkySource");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = downedSkySource;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedSkySource = flags[0];
        }
    }



}