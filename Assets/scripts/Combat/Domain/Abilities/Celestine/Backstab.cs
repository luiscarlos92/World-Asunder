﻿using System;
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
        this.description = "Cuts your enemy in the back 2 squares forward";
        this.preFab = "LazerParticle";
		this.cooldown = 6;
		this.remainingCooldown = 0;
		this.hitBoxes = new Vector2[1];
		this.hitBoxes[0] = new Vector2(2, 0);
		this.framesToResolve = new int[1];
		framesToResolve[0] = 0;
		this.frames = 20;
        this.doneFrames = this.frames;
		this.icon = Resources.Load<Sprite>("Sprites/Icons/Celestine/Backstab");
		this.animationTriggerName = "DefaultAttack";

		this.packet = new EffectPacket(80, 20);
	}

    public override void ApplyEffects(Character character)
    {
        character.HP -= 80;
        character.StunnedFrames = 20;
        character.Stunned = true;
    }
}


