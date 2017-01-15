using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

class Garrote : Ability
{
	public Garrote()
	{
		this.name = "Garrote";
        this.description = "Traps the enemy in front of you, and deals damage over time";
        this.preFab = "Prefabs/LazerParticle";
            
		this.cooldown = 60;
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
		this.icon = Resources.Load<Sprite>("Sprites/Icons/Celestine/Garrote");
		this.animationTriggerName = "DefaultAttack";

		//condition damage/heal, total frames, frame step
//		this.packet = new EffectPacket(50, 0, 180, new Condition(30,180,36));
		this.packet = new EffectPacket(50,180,new Condition(30, 180, 36));
	}

    public override void ApplyEffects(Character character)
    {
        character.HP -= 50;
        character.StunnedFrames = 180;
        character.Stunned = true;
        character.conditionPool.Add(new Condition(30, 180, 5));
    }
}








