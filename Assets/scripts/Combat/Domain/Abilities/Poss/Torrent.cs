using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

class Torrent: Ability
{
	public Torrent()
	{
		this.name = "Torrent";
		this.cooldown = 12;
		this.remainingCooldown = 0;
		Vector2[] hitbox = new Vector2[1];
		hitbox[0] = new Vector2(3, 0);
		this.hitBoxes = hitbox;
		this.frames = 40;

		this.framesToResolve = new int[1];
		framesToResolve[0] = 120;

		this.icon = Resources.Load<Sprite>("Sprites/MegamanSpells/torrent");
		this.animationTriggerName = "DefaultAttack";
		this.packet = new EffectPacket(100, 100);
	}
}


