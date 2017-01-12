using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Enemy : Character
{
    //public Sprite[] sprite;

	public Vector2[] moves;
	public int frameStep = 60;

    public Enemy(Vector2 pos)
    {
        position = pos;
        this.HP = 500;
		this.name = "Poss";
		this.moves = new Vector2[4];
		moves [0] = new Vector2 (1, 0);
		moves [1] = new Vector2 (-1, 0);
		moves [2] = new Vector2 (0, 1);
		moves [3] = new Vector2 (0, -1);

    }

	public Vector2 getNextMove(){
		if (frameStep == 0) {
			if (!checkStuns()) {
				System.Random rnd = new System.Random ();
				var sample = rnd.Next (4);
				frameStep = 30;
				return moves [sample];
			}
		} else
			frameStep--;
		return new Vector2 ();
	}

	public Ability getNextAbility(){
		if (frameStep == 0) {
			if (!checkStuns ()) {
				System.Random rnd = new System.Random ();
				var sample = rnd.Next (5);
				if (sample == 0) {
					return (Ability)(passive as ICloneable).Clone ();
				}
				if (sample == 1) {
					if (abilityQ.remainingCooldown == 0) {
						Debug.Log (abilityQ.name);
						this.AnimationFrames = abilityQ.frames;
						this.AnimationOccuring = true;
						abilityQ.remainingCooldown = abilityQ.cooldown;
				frameStep = 30;

						return (Ability)(abilityQ as ICloneable).Clone ();
					}
				} else if (sample == 2) {
					if (abilityW.remainingCooldown == 0) {
						Debug.Log (abilityW.name);
						this.AnimationFrames = abilityW.frames;
						this.AnimationOccuring = true;
						abilityW.remainingCooldown = abilityW.cooldown;
				frameStep = 30;
						return (Ability)(abilityW as ICloneable).Clone ();
					}
				} else if (sample == 3) {
					if (abilityE.remainingCooldown == 0) {
						Debug.Log (abilityE.name);
						this.AnimationFrames = abilityE.frames;
						this.AnimationOccuring = true;
						abilityE.remainingCooldown = abilityE.cooldown;
				frameStep = 30;
						return (Ability)(abilityE as ICloneable).Clone ();
					}
				} else if (sample == 4) {
					if (abilityR.remainingCooldown == 0) {
						Debug.Log (abilityR.name);
						this.AnimationFrames = abilityR.frames;
						this.AnimationOccuring = true;
						abilityR.remainingCooldown = abilityR.cooldown;
				frameStep = 30;
						return (Ability)(abilityR as ICloneable).Clone ();
					}
				}
			}
		} else
			frameStep--;
		return null;
	}



}
