using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

class BasicShot : Ability
{
    public BasicShot()
    {
        this.name = "BasicShot";
        this.cooldown = 0;
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
        this.icon = Resources.Load<Sprite>("Sprites/MegamanSpells/sword.png");
        this.animationTriggerName = "DefaultAttack";
        this.preFab = "Prefabs/Projectile";
		this.packet = new EffectPacket(5,0);
    }

    public override void ApplyEffects(Character character)
    {
        character.HP -= 5;
    }


}
