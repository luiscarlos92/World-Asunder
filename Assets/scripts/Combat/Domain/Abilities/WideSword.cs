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
        this.damage = 80;
        this.cooldown = 8;
        this.remainingCooldown = 0;
        Vector2[] hitbox = new Vector2[3];
        hitbox[0] = new Vector2(1, 0);
        hitbox[1] = new Vector2(1, 1);
        hitbox[2] = new Vector2(1, -1);
        this.hitBoxes = hitbox;

        this.framesToResolve = new int[3];
        framesToResolve[0] = 0;
        framesToResolve[1] = 0;
        framesToResolve[2] = 0;

        this.packet = new EffectPacket(80, 0, 20);
        this.frames = 20;

        this.icon = Resources.Load<Sprite>("Sprites/MegamanSpells/widesword");
    }
}
