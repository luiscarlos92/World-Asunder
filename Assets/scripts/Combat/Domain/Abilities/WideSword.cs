using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

class WideSword : Ability
{
    public WideSword()
    {
        this.name = "WideSword";
        this.cooldown = 8;
        this.remainingCooldown = 0;
        this.description = "Cuts your enemy 3 square vertically";
        this.preFab = "Prefabs/LazerParticle";
        Vector2[] hitbox = new Vector2[3];
        hitbox[0] = new Vector2(1, 0);
        hitbox[1] = new Vector2(1, 1);
        hitbox[2] = new Vector2(1, -1);
        this.hitBoxes = hitbox;

        this.framesToResolve = new int[3];
        framesToResolve[0] = 0;
        framesToResolve[1] = 0;
        framesToResolve[2] = 0;

        this.packet = new EffectPacket(80, 20);
        this.frames = 20;
        this.doneFrames = this.frames;

        this.icon = Resources.Load<Sprite>("Sprites/MegamanSpells/widesword");
    }

    public override void ApplyEffects(Character character)
    {
        character.HP -= 80;
        character.Stunned = true;
        character.StunnedFrames = 20;
    }

}
