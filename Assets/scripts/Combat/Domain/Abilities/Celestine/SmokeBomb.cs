using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

class SmokeBomb : Ability
{
	public SmokeBomb()
	{
		this.name = "SmokeBomb";
		this.cooldown = 16;
        this.description = "Summon sea currents to blow your enemy and deal damage 3 squares away";
        this.preFab = "Prefabs/font_back";
		this.remainingCooldown = 0;
		this.hitBoxes = new Vector2[5];
		this.hitBoxes[0] = new Vector2(3, 0);
		this.hitBoxes[1] = new Vector2(4, 0);
		this.hitBoxes[2] = new Vector2(2, 0);
		this.hitBoxes[3] = new Vector2(3, 1);
		this.hitBoxes[4] = new Vector2(3, -1);
		this.framesToResolve = new int[5];
		framesToResolve[0] = 20;
		framesToResolve[1] = 20;
		framesToResolve[2] = 20;
		framesToResolve[3] = 20;
		framesToResolve[4] = 20;
		this.frames = 20;
        this.doneFrames = frames;
		this.icon = Resources.Load<Sprite>("Sprites/Icons/Celestine/SmokeBomb");
		this.animationTriggerName = "DefaultAttack";

		this.packet = new EffectPacket(80, 60);
	}

    public override void ApplyEffects(Character character)
    {
        character.HP -= 80;
        character.Stunned = true;
        character.StunnedFrames = 60;
 
    }
}






