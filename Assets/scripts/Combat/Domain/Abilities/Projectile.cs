using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Projectile : Ability
{
    //this is the time in frames it takes for the hitbox in the tiles to change
    //this also means it needs an update function, while the projectile is still in the tile
    public int hitBoxStep;
    //we still use the hitbox vector and travel through it as we move the steps of the 'animation'

    //express this in MORE FRAMES - smaller speed
    //calculate distance between character position and end of tile, woorld coordinates
    public int travelTime;
    //TRAVEL TIME IS INVALID BECAUSE IT DIFFERS ON CHARACTER POSITION
    //so step is time to travel between hitboxes therefore its speed
    public int count = 0;
    public int index = 0;

    //takes N frames to go from orig to end of tile on X,Y,Z>k 
    //take those N frames and choose a step on which the hitbox change will depend
    //the projectile speed on the visuals is equal to N/step 
    public Projectile() : base(){
        this.hitBoxStep = 0;
        this.travelTime = 0;
        this.damage = 5;
        this.hitBoxes = new Vector2[5];
        this.hitBoxes[0] = new Vector2(1, 0);
        this.hitBoxes[1] = new Vector2(2, 0);
        this.hitBoxes[2] = new Vector2(3, 0);
        this.hitBoxes[3] = new Vector2(4, 0);
        this.hitBoxes[4] = new Vector2(5, 0);
    }

    public void Update()
    {
        count++;
        if(count == hitBoxStep)
        {
            count = 0;
            //next hitbox
            index++;
        }
        
    }
    
}
