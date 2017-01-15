using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

class LongSword : Ability
{
    public LongSword()
    {
        this.name = "LongSword";
        this.cooldown = 8;
        this.remainingCooldown = 0;
        this.description = "Cuts your enemy 2 squares forward";
        this.preFab = "LazerParticle";
        Vector2[] hitbox = new Vector2[2];
        hitbox[0] = new Vector2(1, 0);
        hitbox[1] = new Vector2(2, 0);
        this.hitBoxes = hitbox;
        this.frames = 20;
        this.doneFrames = this.frames;

        this.framesToResolve = new int[2];
        framesToResolve[0] = 0;
        framesToResolve[1] = 0;
		this.packet = new EffectPacket(80,20);

        this.icon = Resources.Load<Sprite>("Sprites/MegamanSpells/longsword");
    }

    public override void ApplyEffects(Character character)
    {
        character.HP -= 80;
        character.Stunned = true;
        character.StunnedFrames = 20;
    }
}

