using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

class CannonBarrage : Ability
{
	public CannonBarrage()
	{
		this.name = "CannonBarrage";
		this.cooldown = 12;
		this.relative = false;
		this.remainingCooldown = 0;
		this.hitBoxes = new Vector2[9];
		this.hitBoxes[0] = new Vector2(3, 0);
		this.hitBoxes[1] = new Vector2(4, 1);
		this.hitBoxes[2] = new Vector2(5, 0);
		this.hitBoxes[3] = new Vector2(5, 2);
		this.hitBoxes[4] = new Vector2(3, 2);
		this.hitBoxes[5] = new Vector2(5, 1);
		this.hitBoxes[6] = new Vector2(4, 2);
		this.hitBoxes[7] = new Vector2(3, 1);
		this.hitBoxes[8] = new Vector2(4, 0);
		this.framesToResolve = new int[9];
		framesToResolve[0] = 0;
		framesToResolve[1] = 30;
		framesToResolve[2] = 60;
		framesToResolve [3] = 90;
		framesToResolve[4] = 120;
		framesToResolve[5] = 150;
		framesToResolve[6] = 180;
		framesToResolve[7] = 210;
		framesToResolve[8] = 240;
		this.frames = 20;
		this.icon = Resources.Load<Sprite>("Sprites/MegamanSpells/sword.png");
		this.animationTriggerName = "DefaultAttack";

		this.packet = new EffectPacket(40, 20);
	}


}








