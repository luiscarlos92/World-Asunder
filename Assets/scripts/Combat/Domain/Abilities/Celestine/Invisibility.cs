using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

class Invisibility : Ability
{
	public Invisibility()
	{
		this.name = "Invisibility";
		this.cooldown = 12;
		this.remainingCooldown = 0;
		this.hitBoxes = new Vector2[1];
		this.hitBoxes[0] = new Vector2(0, 0);
		this.framesToResolve = new int[1];
		framesToResolve[0] = 0;
		this.frames = 20;
		this.icon = Resources.Load<Sprite>("Sprites/Icons/Celestine/Invis");
		this.animationTriggerName = "DefaultAttack";

		this.packet = new EffectPacket(new Condition(360));
	}

    public override void Run()
    {
        throw new NotImplementedException();
    }
}




