using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

class Sword : Ability
{
    public Sword()
    {
        this.name = "Sword";
        this.cooldown = 8;
        this.remainingCooldown = 0;
        this.description = "Cuts your enemy 1 square forward";
        this.preFab = "Prefabs/LazerParticle";
        Vector2[] hitbox = new Vector2[1];
        hitbox[0] = new Vector2(1, 0);
        this.hitBoxes = hitbox;
        this.framesToResolve = new int[1];
        framesToResolve[0] = 0;
        this.frames = 20;
        this.icon = Resources.Load<Sprite>("Sprites/MegamanSpells/sword.png");
        this.animationTriggerName = "SwordAttack";

        this.packet = new EffectPacket(80, 20);
    }

    public override void ApplyEffects(Character character)
    {
        character.HP -= 80;
        character.Stunned = true;
        character.StunnedFrames = 20;
    }


}
