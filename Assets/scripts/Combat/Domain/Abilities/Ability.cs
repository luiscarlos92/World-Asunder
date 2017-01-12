using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Ability : ICloneable{
    public string name;
    public Vector2[] hitBoxes;
    public float cooldown;
    public float remainingCooldown;
    //frames it takes to complete
    public int frames;
    //parameter to see how many frames were already done
    public int doneFrames;
	public bool relative = true;
    //name of the parameter on the ide to trigger the sprite animation
    public string animationTriggerName = "DefaultAttack";
    //frames until hitbox is allowed to be active
    public int[] framesToResolve;
    public EffectPacket packet;

    //ICON TO WRITE TO UI
    public Sprite icon;

    public Ability()
    {
        name = "";
        this.hitBoxes = new Vector2[1];
        hitBoxes[0] = new Vector2(0, 0);
        cooldown = 0;
        remainingCooldown = 0;
        frames = 0;
        this.doneFrames = 0;
        this.animationTriggerName = "DefaultAttack";
        packet = new EffectPacket();
    }
    public Ability(string _name, Vector2[] _hitBoxes, float _cd, int _frames)
    {
        name = _name;
        hitBoxes = _hitBoxes;
        cooldown = _cd;
        frames = _frames;
        this.doneFrames = 0;
    }


    object ICloneable.Clone()
    {
        Ability ability = (Ability)this.MemberwiseClone();
        return ability;
    }
}
