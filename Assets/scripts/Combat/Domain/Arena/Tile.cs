using UnityEngine;
using System.Collections;

public class Tile{
    public bool Occupied;
    public bool HitBoxActive;
    public bool selfAllegiance;
    public Character gameObject;
    public Ability ability;
    //AttackObject?
    //Panel allegiance
    //broken ?

      
	// Use this for initialization
	public Tile() {
        this.Occupied = false;
        this.selfAllegiance = true;
        this.gameObject = null;
        //THIS IS NOT NEEDED ANYMORE
        this.ability = null;
        this.HitBoxActive = false;
	}

	
}
