using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Enemy : Character
{
    //public Sprite[] sprite;

    public Enemy(Vector2 pos)
    {
        position = pos;
        this.HP = 500;
    }
}
