using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile{
    public bool Occupied;
    //wont be needed anymore
    public bool HitBoxActive;
    public bool selfAllegiance;
    public Character gameObject;
    //if hitbox is active then this is not null
    public Ability hitbox;
    //all the abilitites cast on this panel
    public List<Hitbox> pool;
    //AttackObject?
    //Panel allegiance
    //broken ?

      
	// Use this for initialization
	public Tile() {
        this.Occupied = false;
        this.selfAllegiance = true;
        this.gameObject = null;
        //THIS IS NOT NEEDED ANYMORE
        this.HitBoxActive = false;
        this.pool = new List<Hitbox>();
	}

    //this activates the hitbox and cleans the list at the same time
    public void Update()
    {
        this.hitbox = null;
        for (int i = 0; i < pool.Count; i++)
        {
            pool[i].Update();
            if ( pool[i].framesToResolve <= 0)
            {
                //begin active phase
                //this prioritizes the oldest ability used on this tile. 
                pool[i].ability.Update();
                if (pool[i].ability.doneFrames >= 0)
                {
                    this.hitbox = pool[i].ability;
                    
                }
                else
                    pool.Remove(pool[i]);
            }
        }
        
    }

	
}
