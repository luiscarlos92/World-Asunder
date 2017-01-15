using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

class DirtyTricks : Ability
{
	public DirtyTricks()
	{
		this.name = "DirtyTricks";
		this.cooldown = 8;
		this.remainingCooldown = 0;
        this.description = "Shoots a sucker bullet dealing damage and stunning your enemy";
        this.preFab = "Prefabs/Projectile";
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
		this.icon = Resources.Load<Sprite>("Sprites/Icons/Poss/DirtyTricks");
		this.animationTriggerName = "DefaultAttack";

		this.packet = new EffectPacket(80,20);
	}

    public override void ApplyEffects(Character character)
    {
        character.HP -= 80;
        character.Stunned = true;
        character.StunnedFrames = 120;
    }
}






