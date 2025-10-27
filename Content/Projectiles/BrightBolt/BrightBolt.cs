using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Cryolith.Content.Projectiles.BrightBolt
{
    public class BrightBolt : ModProjectile
    {
        // Configurable defaults
        public int LifetimeTicks { get; private set; } = 180;
        public int FrameCount { get; private set; } = 3;
        public int BaseDamage { get; private set; } = 50;
        public float Speed { get; private set; } = 20f;

        // Animation state
        private int _frame = 0;
        private int _frameCounter = 0;

        public override void SetDefaults()
        {
            // Size and visuals
            Projectile.width = 34;
            Projectile.height = 40;

            // Movement and collision
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;

            // Damage type
            Projectile.DamageType = DamageClass.Magic;

            // Initial velocity: forward along X. If you want aiming, replace this in AI or when spawned.
            Projectile.velocity = new Vector2(Speed, 0f);

            // Ensure values reflect current fields
            LifetimeTicks = 180;
            FrameCount = 3;
        }

        public override void AI()
        {
            // Frame animation
            _frameCounter++;
            if (_frameCounter >= 6)
            {
                _frameCounter = 0;
                _frame = (_frame + 1) % FrameCount;
                Projectile.frame = _frame;
            }

            // Lifetime management
            LifetimeTicks--;
            if (LifetimeTicks <= 0)
            {
                SpawnEndOfLifeDust();
                Projectile.Kill();
            }
        }

        private void SpawnEndOfLifeDust()
        {
            // Pick a dust type that exists in your version. Replace if needed.
            int dustType = DustID.BlueCrystalShard;

            for (int i = 0; i < 12; i++)
            {
                // Random outward spread
                Vector2 dir = Main.rand.NextVector2Circular(1f, 1f);
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, dustType);
                if (dust != null)
                {
                    dust.velocity = dir * (2.0f + Main.rand.NextFloat(0.0f, 1.5f));
                    dust.noGravity = true;
                    dust.scale *= 1.2f;
                    dust.color = Color.LightBlue;
                }
            }

            // Light emission
            Lighting.AddLight(Projectile.Center, 0.4f, 0.6f, 1f);
        }
    }
}