using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

class Backstab : Ability
{
	public Backstab()
	{
		this.name = "Backstab";
		this.cooldown = 6;
		this.remainingCooldown = 0;
		this.hitBoxes = new Vector2[1];
		this.hitBoxes[0] = new Vector2(2, 0);
		this.framesToResolve = new int[1];
		framesToResolve[0] = 0;
		this.frames = 20;
		this.icon = Resources.Load<Sprite>("Sprites/Icons/Celestine/Backstab");
		this.animationTriggerName = "DefaultAttack";

		this.packet = new EffectPacket(80, 20);
	}


}


