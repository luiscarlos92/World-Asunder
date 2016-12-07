using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Character
{
    public Vector2 position;
    public int HP;
    public const int MAXHP = 100;

    public Ability passive;
    public Ability abilityQ;
    public Ability abilityW;
    public Ability abilityE;
    public Ability abilityR;

    public bool Stunned;
    public int StunnedFrames;

    public bool AnimationOccuring;
    public int AnimationFrames;

    public Character() {
        position = new Vector2(1, 1);
        HP = MAXHP;
        Stunned = false;
        StunnedFrames = 0;
        passive = new BasicShot();
        abilityQ = new Sword();
        abilityW = new WideSword();
        abilityE = new LongSword();
        abilityR = new Torrent();
        this.AnimationOccuring = false;
    }

    public void SetAbilities(Ability[] abilities)
    {
        passive = abilities[0];
        abilityQ = abilities[1];
        abilityW = abilities[2];
        abilityE = abilities[3];
        abilityR = abilities[4];

    }

    public void CalculateEffects(Ability ability)
    {
        if (!Stunned)
        {
            if(ability.damage > this.HP)
            {
                this.HP -= this.HP;
            }
            else
                this.HP -= ability.damage;
            this.Stunned = true;
            this.StunnedFrames = 20;
            Debug.Log(HP);
        }
    }

    public void CalculateEffects(EffectPacket packet)
    {
        if (!Stunned)
        {
            this.HP -= packet.dmg;
            this.HP += packet.heal;
            this.StunnedFrames = packet.stunFrames;
            this.Stunned = true;
            //Debug.Log(HP);
            //Debug.Log(StunnedFrames);
        }
    }

    public bool checkStuns()
    {
        //Debug.Log("Stunned " + Stunned +"Animation " + AnimationOccuring );
        return Stunned || AnimationOccuring;
    }
    public Vector2 HandleMovementInput()
    {
        if (!checkStuns())
        {

            if (Input.GetKeyDown("up"))
            {
                return new Vector2(0, 1);
            }
            else if (Input.GetKeyDown("down"))
            {
                return new Vector2(0, -1);
            }
            else if (Input.GetKeyDown("left"))
            {
                return new Vector2(-1, 0);
            }
            else if (Input.GetKeyDown("right"))
            {
                return new Vector2(1, 0);
            }
        }
        return new Vector2();
    }

    public Ability HandleCombatInput()
    {
        if (!checkStuns())
        {

            if (Input.GetKeyDown("space"))
            {
                return (Ability)(passive as ICloneable).Clone();
            }
            if (Input.GetKeyDown("q"))
            {
                if (abilityQ.remainingCooldown == 0)
                {
                    Debug.Log(abilityQ.name);
                    this.AnimationFrames = abilityQ.frames;
                    this.AnimationOccuring = true;
                    abilityQ.remainingCooldown = abilityQ.cooldown;
                    
                    return (Ability)(abilityQ as ICloneable).Clone();
                }
            }
            else if (Input.GetKeyDown("w"))
            {
                if (abilityW.remainingCooldown == 0)
                {
                    Debug.Log(abilityW.name);
                    this.AnimationFrames = abilityW.frames;
                    this.AnimationOccuring = true;
                    abilityW.remainingCooldown = abilityW.cooldown;
                    return (Ability)(abilityW as ICloneable).Clone();
                }
            }
            else if (Input.GetKeyDown("e"))
            {
                if (abilityE.remainingCooldown == 0)
                {
                    Debug.Log(abilityE.name);
                    this.AnimationFrames = abilityE.frames;
                    this.AnimationOccuring = true;
                    abilityE.remainingCooldown = abilityE.cooldown;
                    return (Ability)(abilityE as ICloneable).Clone();
                }
            }
            else if (Input.GetKeyDown("r"))
            {
                if (abilityR.remainingCooldown == 0)
                {
                    Debug.Log(abilityR.name);
                    this.AnimationFrames = abilityR.frames;
                    this.AnimationOccuring = true;
                    abilityR.remainingCooldown = abilityR.cooldown;
                    return (Ability)(abilityR as ICloneable).Clone();
                }
            }
        }
        return null;
    }

    //public Ability HandleShootInput()
    //{
    //        if (Input.GetKeyDown("space"))
    //        {
    //        //single shot
    //        //Debug.Log("Pressed space bar one single time")
    //        return 0;
    //        }
    //        else if (Input.GetKey("space"))
    //        {
    //        //charged shot
    //        //Debug.Log("still pressing space bar");
    //        return 1;
    //        }
    //    return -1;
    //}
    public void Update()
    {
        if (this.StunnedFrames > 0 && Stunned)
            this.StunnedFrames--;
        else
            this.Stunned = false;

        if (this.AnimationFrames > 0 && AnimationOccuring)
        {
            this.AnimationFrames--;
        }
        else
            this.AnimationOccuring = false;
        //game is locked at 60 frames, so we'll use that to our advantage
        //60 fps -> 1 frame -> 1/60th of a second which is rougly 0.016
        //at each step we subtract 0.016
        //BAD IMPLEMENTION
        //FIXME do it with timestep
        if (this.abilityQ.remainingCooldown > 0)
            abilityQ.remainingCooldown -= 0.016f;
        else
            abilityQ.remainingCooldown = 0;
        if (this.abilityW.remainingCooldown > 0)
            abilityW.remainingCooldown -= 0.016f;
        else
            abilityW.remainingCooldown = 0;
        if (this.abilityE.remainingCooldown > 0)
            abilityE.remainingCooldown -= 0.016f;
        else
            abilityE.remainingCooldown = 0;
        if (this.abilityR.remainingCooldown > 0)
            abilityR.remainingCooldown -= 0.016f;
        else
            abilityR.remainingCooldown = 0;
        //Debug.Log("Stunned Frames: " + StunnedFrames + "animation frames: " + AnimationFrames);
        //Debug.Log(abilityQ.remainingCooldown + "/" + abilityQ.cooldown);

    }

    


}
