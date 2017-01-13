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
		Vector2[] hitbox = new Vector2[3];
		hitbox[0] = new Vector2(3, 0);
		hitbox[1] = new Vector2(3, 1);
		hitbox[2] = new Vector2(3, -1);
		this.hitBoxes = hitbox;
		this.frames = 40;

		this.framesToResolve = new int[3];
		framesToResolve[0] = 120;
		framesToResolve[1] = 120;
		framesToResolve[2] = 120;

		this.icon = Resources.Load<Sprite>("Sprites/Icons/Poss/Torrent");
		this.animationTriggerName = "DefaultAttack";
		this.packet = new EffectPacket(100, 100);
	}
}


