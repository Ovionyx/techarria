﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Techarria.Content.Dusts
{
	/// <summary>
	/// Particles for item transfer
	/// </summary>
    internal class Transfer : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.0f;
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale = 1f;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity * dust.scale;
			dust.rotation += (float) (dust.velocity.Length() / Math.PI);
			dust.scale *= 0.94f;

			float light = 1f * dust.scale;

			Lighting.AddLight(dust.position, light, light, light);

			if (dust.scale < 0.1f)
			{
				dust.active = false;
			}

			return false;
		}
	}
}
