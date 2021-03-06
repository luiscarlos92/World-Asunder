﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using System.Linq;

public class Arena
{
    
    //this class represents the game logic
    //has all tiles and represents the current state of the world
    //the idea is to separate game logic from world representation

    Tile[,] arena;
    public Character character;
	public Enemy enemy;

    Dictionary<Vector2, Hitbox> HitboxPool;
    Dictionary<Vector2, List<Hitbox>> HitboxListPool;
    

    public string charAnimation = "";
    public string enemyAnimation = "";
    /// <summary>
    /// ////////////////////////////////////////////////////
    /// </summary>
    /// <param name="abilities"></param>
    /// <param name="enemy"></param>

    public Arena(Character chara, Enemy enemy)
    {
        //this.HitboxPool = new Dictionary<Vector2, Hitbox>();

        //list implementation
        this.HitboxListPool = new Dictionary<Vector2, List<Hitbox>>();
        this.HitboxListPool[new Vector2(0, 0)] = new List<Hitbox>();
        this.HitboxListPool[new Vector2(0, 1)] = new List<Hitbox>();
        this.HitboxListPool[new Vector2(0, 2)] = new List<Hitbox>();
        this.HitboxListPool[new Vector2(1, 0)] = new List<Hitbox>();
        this.HitboxListPool[new Vector2(1, 1)] = new List<Hitbox>();
        this.HitboxListPool[new Vector2(1, 2)] = new List<Hitbox>();
        this.HitboxListPool[new Vector2(2, 0)] = new List<Hitbox>();
        this.HitboxListPool[new Vector2(2, 1)] = new List<Hitbox>();
        this.HitboxListPool[new Vector2(2, 2)] = new List<Hitbox>();
        this.HitboxListPool[new Vector2(3, 0)] = new List<Hitbox>();
        this.HitboxListPool[new Vector2(3, 1)] = new List<Hitbox>();
        this.HitboxListPool[new Vector2(3, 2)] = new List<Hitbox>();
        this.HitboxListPool[new Vector2(4, 0)] = new List<Hitbox>();
        this.HitboxListPool[new Vector2(4, 1)] = new List<Hitbox>();
        this.HitboxListPool[new Vector2(4, 2)] = new List<Hitbox>();
        this.HitboxListPool[new Vector2(5, 0)] = new List<Hitbox>();
        this.HitboxListPool[new Vector2(5, 1)] = new List<Hitbox>();
        this.HitboxListPool[new Vector2(5, 2)] = new List<Hitbox>();
        arena = new Tile[6, 3];

        //this.enemy = new Enemy(new Vector2(3, 1));
        this.character = chara;
        this.enemy = enemy;
        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                Tile tile = new Tile();
                if (x < 3)
                    tile.selfAllegiance = true;
                else
                    tile.selfAllegiance = false;
                if (new Vector2(x, y) == character.position)
                {
                    tile.gameObject = character;
                    tile.Occupied = true;
                }
                if (new Vector2(x, y) == enemy.position)
                {
                    tile.gameObject = enemy;
                    tile.Occupied = true;
                }
                arena[x, y] = tile;
            }
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public List<Vector2> getHitboxes()
    {
        return HitboxPool.Keys.ToList();
    }

    public Tile[,] getArena()
    {
        return arena;
    }

    public List<Hitbox> getHitboxPool()
    {

        //return HitboxPool.Values.ToList();
        var ListOfLists = HitboxListPool.Values.ToList();
        var result = new List<Hitbox>();
        foreach(var list in ListOfLists)
        {
            result.Union(list).ToList();
        }
        Debug.Log("hitbox list of lists ");
        var i = 0;
        foreach(var hit in result)
        {
            Debug.Log("hitbox found" + i);
            i++;
        }
        return result;

    }
    public Dictionary<Vector2, Hitbox> getPool()
    {
        return HitboxPool;
    }

    public Dictionary<Vector2, List<Hitbox>> getPoolList()
    {
        return HitboxListPool;
    }

    public Tile getTile(Vector2 position)
    {
        //TODO
        //checkar range
       
            return arena[(int)position.x, (int)position.y];
        
        
    }
    /// <summary>
    /// ///////////////////////////////////////////
    /// </summary>
    public void HandleInput()
    {
        Vector2 move = character.HandleMovementInput();
        Move(character, move);
		move = enemy.getNextMove ();
		Move2(enemy, move);
        Ability ability = character.HandleCombatInput();
		Execute(ability,character);
        ability = enemy.getNextAbility();
        Execute(ability, enemy);
    }

    void Move(Character target, Vector2 move)
    {
        var destination = target.position + move;
        if (checkValidTile(destination))
        {
			if (getTile (destination).selfAllegiance) {
            getTile(target.position).Occupied = false;
            getTile(target.position).gameObject = null;
            target.position = destination;
            getTile(destination).Occupied = true;
            getTile(destination).gameObject = target;
//			Debug.Log (target.name);
			}
        }
    }

	void Move2(Enemy target, Vector2 move) {
        var destination = target.position + move;
        if (checkValidTile(destination))
        {
			if (!getTile (destination).selfAllegiance) {
				getTile (target.position).Occupied = false;
				getTile (target.position).gameObject = null;
				target.position = destination;
				getTile (destination).Occupied = true;
				getTile (destination).gameObject = target;
//				Debug.Log (target.name);
			}
        }
    }
    bool checkValidTile(Vector2 move)
    {
        if ((move.x <= 5) &&
            (move.x >= 0) &&
            (move.y <= 2) &&
            (move.y >= 0) &&
            !getTile(move).Occupied)
        {
            return true;
        }
        return false;
    }

    bool checkHitbox(Vector2 move)
    {
        if ((move.x <= 5) &&
            (move.x >= 0) &&
            (move.y <= 2) &&
            (move.y >= 0))
        {
            return true;
        }
        return false;
    }

    void Execute(Ability ability, Character sender)
    {
		if (ability == null) {
			return;
		}
        if (sender.name == "Hecte")
        {
            this.charAnimation = ability.animationTriggerName;
        }
        else
            this.enemyAnimation = ability.animationTriggerName;

        ability.origin = sender.position;

        //this phase is where the ability hitboxes are distributed
        //so here we just calculate in which tiles to put our abilities

        //        for(int i = 0; i<ability.hitBoxes.Length; i++)
        //        {
        //            Hitbox hitbox = new Hitbox(ability.framesToResolve[i], ability);

        //            //list implementation
        //			if (ability.relative) {
        ////				Debug.Log ("here");
        //				if(sender.GetType().ToString() == "Enemy")
        //					HitboxListPool [sender.position - ability.hitBoxes [i]].Add (hitbox);
        //				else
        //					HitboxListPool [sender.position + ability.hitBoxes [i]].Add (hitbox);
        //			}
        //            else
        //            {
        //                if (sender.GetType().ToString() == "Enemy")

        //                    HitboxListPool[new Vector2(6, 3) - ability.hitBoxes[i] ].Add(hitbox);
        //                else
        //                    HitboxListPool[ability.hitBoxes[i]].Add(hitbox);
        //            }
        //            //Debug.Log("Hitbox Added with " + hitbox.ability.name + "," + hitbox.framesToResolve + "," + hitbox.active);
        //        }
        for (int i = 0; i < ability.hitBoxes.Length; i++)
        {
            var copy = (Ability)(ability as ICloneable).Clone();
            //Debug.Log(ability.name + " " + i.ToString());
            //check wether hitbox is within range
            Hitbox hitbox = null;
            Vector2 tilePos = new Vector2(10,10);
            //list implementation
            hitbox = new Hitbox(ability.framesToResolve[i], copy);
            if (ability.relative)
            {
                if (sender.GetType().ToString() == "Enemy")
                    tilePos = sender.position - ability.hitBoxes[i];
                else
                    tilePos = sender.position + ability.hitBoxes[i];
            }
            else
            {
                if (sender.GetType().ToString() == "Enemy")
                    tilePos = new Vector2(5, 2) - ability.hitBoxes[i];
                else
                {
                    tilePos = ability.hitBoxes[i];
                }
            }
            if (tilePos != null && checkHitbox(tilePos))
            {
                getTile(tilePos).pool.Add(hitbox);
                //Debug.Log("Hitbox Added with " + hitbox.ability.name + "," + hitbox.framesToResolve + "," + hitbox.active + " " + tilePos.ToString());
            }
        }
    }


    void checkCollisions()
    {
        /*List<Hitbox> hitboxList;
        if((hitboxList = HitboxListPool[character.position]).Count != 0)
        {
            foreach(var hitbox in hitboxList)
            {
                if (hitbox.active)
                    this.character.CalculateEffects(hitbox.ability.packet);
            }
        }

        if((hitboxList = HitboxListPool[enemy.position]).Count != 0)
        {
            foreach(var hitbox in hitboxList)
            {
				if (hitbox.active) {
					this.enemy.CalculateEffects (hitbox.ability.packet);

				}
            }}
        //catch (Exception e)
        //{
        //    Debug.Log(e.Message);
        //}*/
        Ability ability = getTile(this.character.position).hitbox;
        if (ability != null && !this.character.Stunned && !(this.character.immuneFrames > 0))
            ability.ApplyEffects(this.character);
        ability = getTile(this.enemy.position).hitbox;
        if (ability != null && !this.enemy.Stunned && !(this.enemy.immuneFrames > 0))
            ability.ApplyEffects(this.enemy);
    }

    //void UpdateHitboxes()
    //{
    //    foreach(var hitboxList in HitboxListPool.Values)
    //    {
    //        foreach(var hitbox in hitboxList)
    //        {
    //            hitbox.framesToResolve--;
    //            if (!(hitbox.ability.doneFrames == hitbox.ability.frames) && hitbox.active)
    //                hitbox.ability.doneFrames++; 
    //        }
    //    }

    //}

    //void ResolveHitboxes()
    //{
    //    //TODO
    //    //have to change to search keys because i 
    //    foreach(var hitboxList in HitboxListPool.Values)
    //    {
    //        for(int i = 0; i < hitboxList.Count; i++)
    //        {
    //            var hitbox = hitboxList[i];
    //            if (hitbox.framesToResolve <= 0)
    //            {
    //                hitbox.active = true;
    //                hitbox.ability.Run();
                    
    //            }
    //            if (hitbox.ability.doneFrames == hitbox.ability.frames) hitboxList.Remove(hitbox);
    //        }
    //    }
    //}

    void UpdateCharacters()
    {
        character.Update();
        enemy.Update();
    }

    void UpdateTiles()
    {
        for(int x = 0; x < 6; x++)
        {
            for(int y = 0; y < 3; y++)
            {
                arena[x, y].Update();
            }
        }
    }
    public void Update()
    {
        HandleInput();
        //resolve first
        UpdateTiles();
        UpdateCharacters();
        //ResolveHitboxes();
        checkCollisions();
        //updating tile takes care of this because all frame related stuff is treated of inside
        //UpdateHitboxes(); 


    }
}
