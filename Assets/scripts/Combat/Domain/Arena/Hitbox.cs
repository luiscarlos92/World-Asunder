using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Hitbox
{
    //idea!
    //maybe do a difficult to master stuff
    //fix an error!
    //the dictionary only allows one hitbox per tile, but!
    //the non active hitboxes will clutters things that wanna do damage so
    //dictionary <vector, list<hitbox>>
    public int framesToResolve;
    public bool active;
    public Ability ability;

    public Hitbox()
    {
        this.framesToResolve = 0;
        this.active = false;
        this.ability = null;
    }
    
    public Hitbox(int frames, Ability ability)
    {
        this.framesToResolve = frames;
        this.active = false;
        this.ability = ability;
    }
}
