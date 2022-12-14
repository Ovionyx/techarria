using System;
using Terraria;
using Terraria.ModLoader;

namespace Techarria.Content.Dusts
{
    internal class Wormhole : ModDust
	{
		public static int timer = 0;

		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 1.0f;
			dust.noGravity = true;
			dust.noLight = true;
			dust.rotation = 0;
			dust.scale = 1f;
			dust.frame.X = new Random().Next(4) * 8;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity * ((256 - dust.alpha) / 256f);
			dust.alpha += 4;

			float light = 1f * ((255 - dust.alpha) / 255f);

			Lighting.AddLight(dust.position, light * 0.75f, 0f, light);

			timer++;
			timer %= 15;
			if (timer == 0)
            {
				dust.frame.X += 8;
				dust.frame.X %= 32;
            }

			if (dust.alpha >= 256)
			{
				dust.active = false;
			}

			return false;
		}
	}
}
