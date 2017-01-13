using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Character
{
    public Sprite sprite;
    public Vector2 position;
    public int HP;
	public string name;
    public const int MAXHP = 100;
    public string spritePath;

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
		this.name = "Hecte";

    }

    public Character(string name, Ability[] abilities)
    {
        position = new Vector2(1, 1);
        HP = MAXHP;
        Stunned = false;
        StunnedFrames = 0;
        this.AnimationOccuring = false;
        this.name = name;
        this.passive = abilities[0];
        this.abilityQ = abilities[1];
        this.abilityW = abilities[2];
        this.abilityE = abilities[3];
        this.abilityR = abilities[4];
    }

    public void SetAbilities(Ability[] abilities)
    {
        this.passive = abilities[0];
        this.abilityQ = abilities[1];
        this.abilityW = abilities[2];
        this.abilityE = abilities[3];
        this.abilityR = abilities[4];

    }

    public void CalculateEffects(EffectPacket packet)
    {
        if (!Stunned)
        {
            this.HP -= packet.dmg;
            
            this.StunnedFrames = packet.stunFrames;
            this.Stunned = true;
//			Debug.Log(HP + " " + this.name);
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
                if (passive.remainingCooldown == 0)
                {
                    Debug.Log(passive.name);
                    this.AnimationFrames = passive.frames;
                    this.AnimationOccuring = true;
                    passive.remainingCooldown = passive.cooldown;

                    return (Ability)(passive as ICloneable).Clone();
                }
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
        if (this.passive.remainingCooldown > 0)
            passive.remainingCooldown -= 0.016f;
        else
            passive.remainingCooldown = 0;

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

//		Debug.Log (this.name);
        //Debug.Log("Stunned Frames: " + StunnedFrames + "animation frames: " + AnimationFrames);
//		Debug.Log(this.name + " " + abilityQ.remainingCooldown + "/" + abilityQ.cooldown);

    }

    


}
