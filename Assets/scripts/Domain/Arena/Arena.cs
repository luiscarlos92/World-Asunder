using UnityEngine;
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
    public Character enemy;

    Dictionary<Vector2, Hitbox> HitboxPool;
    

    public string charAnimation = "";
    public string enemyAnimation = "";
    /// <summary>
    /// ////////////////////////////////////////////////////
    /// </summary>
    /// <param name="abilities"></param>
    /// <param name="enemy"></param>

    public Arena(Ability[] abilities, Enemy enemy)
    {
        this.HitboxPool = new Dictionary<Vector2, Hitbox>();
        arena = new Tile[6, 3];
        this.character = new Character();
        this.character.SetAbilities(abilities);
        //this.enemy = new Enemy(new Vector2(3, 1));
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
    public List<Vector2> getHitboxes()
    {
        return HitboxPool.Keys.ToList();
    }

    public List<Hitbox> getHitboxPool()
    {

        return HitboxPool.Values.ToList();
    }
    public Dictionary<Vector2, Hitbox> getPool()
    {
        return HitboxPool;
    }

    public Tile getTile(Vector2 position)
    {
        return arena[(int)position.x, (int)position.y];
    }

    public void HandleInput()
    {
        Vector2 move = character.HandleMovementInput();
        Move(character, move);
        Ability ability = character.HandleCombatInput();
        if(ability != null)
            Debug.Log(ability.doneFrames);
        Execute(ability);
        //Ability shoot = character.HandleShootInput();
        //Shoot(shoot);
    }

    void Move(Character target, Vector2 move)
    {
        var destination = target.position + move;
        if (checkValidTile(destination))
        {
            getTile(target.position).Occupied = false;
            getTile(target.position).gameObject = null;
            target.position = destination;
            getTile(destination).Occupied = true;
            getTile(destination).gameObject = target;
        }
    }

    bool checkValidTile(Vector2 move)
    {
        if ((move.x <= 5) &&
            (move.x >= 0) &&
            (move.y <= 2) &&
            (move.y >= 0) &&
            getTile(move).selfAllegiance &&
            !getTile(move).Occupied)
        {
            return true;
        }
        return false;
    }

    void Execute(Ability ability)
    {
        if (ability == null) return;

        //if(ability is Projectile)
        //{
        //    abilityPool.Add(ability);
        //    return;
        //}
        this.charAnimation = ability.animationTriggerName;

        //GameObject.Find("Player").GetComponent<Animator>().SetTrigger(ability.animationTriggerName);

        //foreach (var hit in ability.hitBoxes)
        //{

            //var tile = getTile(character.position + hit);
            //tile.HitBoxActive = true;
            //tile.ability = ability;

            //hitbox implementation
            //do array implementation of indexes for arrays of framesToResolve

        //}

        for(int i = 0; i<ability.hitBoxes.Length; i++)
        {
            Hitbox hitbox = new Hitbox(ability.framesToResolve[i], ability);
            HitboxPool.Add(character.position + ability.hitBoxes[i], hitbox);
            //Debug.Log("Hitbox Added with " + hitbox.ability.name + "," + hitbox.framesToResolve + "," + hitbox.active);
        }
    }


    void checkCollisions()
    {
        //for (int x = 0; x < 6; x++)
        //{
        //    for (int y = 0; y < 3; y++)
        //    {
        //        var tile = getTile(new Vector2(x, y));
        //        if(tile.gameObject != null && tile.HitBoxActive)
        //        {
        //            Debug.Log("Collision Detected at: " + x + "," + y);
        //            //maybe just tile.CalculateEffects()?
        //            tile.gameObject.CalculateEffects(tile.ability);
        //        }
        //    }
        //}
        //hitbox implementation
        Hitbox hitbox;
        if (HitboxPool.ContainsKey(this.character.position)){
            hitbox = HitboxPool[this.character.position];
            if ((hitbox != null) && hitbox.active)
            {
                this.character.CalculateEffects(hitbox.ability.packet);
            }
        }

        if (HitboxPool.ContainsKey(this.enemy.position))
        {
            if (((hitbox = HitboxPool[this.enemy.position]) != null) && hitbox.active)
            {
                this.enemy.CalculateEffects(hitbox.ability.packet);
            }
        }
        //catch (Exception e)
        //{
        //    Debug.Log(e.Message);
        //}
    }

    void UpdateHitboxes()
    {
        //for (int x = 0; x < 6; x++)
        //{
        //    for (int y = 0; y < 3; y++)
        //    {
        //        var tile = getTile(new Vector2(x, y));
        //        if (tile.ability != null)
        //            tile.Update();
        //        else
        //            tile.HitBoxActive = false;
        //        //tile.ability.doneFrames++;
        //        tile.ability = null;
        //    }
        //}
        if (HitboxPool.Count == 0) return;

        foreach (Hitbox hitbox in HitboxPool.Values)
        {
            hitbox.framesToResolve--;
            //Debug.Log(hitbox.framesToResolve);
            if (!(hitbox.ability.doneFrames == hitbox.ability.frames) && hitbox.active)
            {
                hitbox.ability.doneFrames++;
            }
        }

    }

    void ResolveHitboxes()
    {
        if (HitboxPool.Count == 0) return;
        var vectors = HitboxPool.Keys.ToList();
       
        foreach(Vector2 position  in vectors)
        {
            if(HitboxPool[position].framesToResolve < 0)
            {
                //Debug.Log(position + " " + HitboxPool[position].ability.name);
                HitboxPool[position].active = true;
            }
            //cleanup
            if(HitboxPool[position].ability.doneFrames == HitboxPool[position].ability.frames){
                HitboxPool.Remove(position);
            }
        }
    }

    void UpdateCharacters()
    {
        character.Update();
        enemy.Update();
    }

    public void Update()
    {
        HandleInput();
        ResolveHitboxes();
        checkCollisions();
        UpdateHitboxes();
        UpdateCharacters();


    }
}
