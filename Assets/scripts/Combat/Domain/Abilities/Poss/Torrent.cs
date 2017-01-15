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
        this.description = "Summon sea currents 3 squares away to surprise your enemy, and stop them in their tracks";
        this.preFab = "Prefabs/font_back";
		Vector2[] hitbox = new Vector2[3];
		hitbox[0] = new Vector2(3, 0);
		hitbox[1] = new Vector2(3, 1);
		hitbox[2] = new Vector2(3, -1);
		this.hitBoxes = hitbox;
		this.frames = 40;
        this.doneFrames = this.frames;

		this.framesToResolve = new int[3];
		framesToResolve[0] = 120;
		framesToResolve[1] = 120;
		framesToResolve[2] = 120;

		this.icon = Resources.Load<Sprite>("Sprites/Icons/Poss/Torrent");
		this.animationTriggerName = "DefaultAttack";
		this.packet = new EffectPacket(100, 100);
	}
    public override void ApplyEffects(Character character)
    {
        character.HP -= 100;
        character.Stunned = true;
        character.StunnedFrames = 100;
    }
}


