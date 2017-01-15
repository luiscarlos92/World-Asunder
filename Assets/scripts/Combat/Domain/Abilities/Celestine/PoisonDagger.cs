﻿using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

class PoisonDagger : Ability
{
	public PoisonDagger()
	{
		this.name = "PoisonDagger";
        this.description = "Throws a poisoned dagger at your enemy, dealing damage over time";
        this.preFab = "Projectile";

		this.cooldown = 4;
		this.remainingCooldown = 0;
		this.hitBoxes = new Vector2[5];
		this.hitBoxes[0] = new Vector2(1, 0);
		this.hitBoxes[1] = new Vector2(2, 0);
		this.hitBoxes[2] = new Vector2(3, 0);
		this.hitBoxes[3] = new Vector2(4, 0);
		this.hitBoxes[4] = new Vector2(5, 0);
		this.framesToResolve = new int[5];
		framesToResolve[0] = 0;
		framesToResolve[1] = 1;
		framesToResolve[2] = 2;
		framesToResolve[3] = 3;
		framesToResolve[4] = 4;
		this.frames = 20;
        this.doneFrames = this.frames;
		this.icon = Resources.Load<Sprite>("Sprites/Icons/Celestine/PoisonDagger");
		this.animationTriggerName = "DefaultAttack";

		this.packet = new EffectPacket(new Condition(15,180,36));
	}

    public override void ApplyEffects(Character character)
    {
        character.Stunned = true;
        character.StunnedFrames = 20;
        character.conditionPool.Add(new Condition(15, 180, 5)); 
    }
}
