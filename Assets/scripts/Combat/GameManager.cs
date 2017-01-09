using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //MAP RELATED
    //change tile to a tileclass that has a sprite animation
    public GameObject tileObj;
    public Vector2 mapSize = new Vector2(6, 3);
    //tile separation factor
    private float percentOutline = 0.07f;

    //GAME RELATED

    public GameObject character;
    public GameObject enemy;

    public GameObject[,] arena;
    public Arena logicArena;


    public Ability[] abilities;

    //UI RELATED
    private GameObject healthBarCharacter;
    private GameObject healthBarEnemy;
    private List<GameObject> healthBars;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void Start()
    {

        arena = new GameObject[6, 3];
        this.abilities = new Ability[5];
        abilities[0] = new BasicShot();
        abilities[1] = new Sword();
        abilities[2] = new WideSword();
        abilities[3] = new LongSword();
        abilities[4] = new Torrent();
        //Sprite bg = Resources.Load<Sprite>("Sprites/Background/background");
        //GameObject.Find("Background").GetComponent<Image>().sprite = bg;
        Enemy enemy = new Enemy(new Vector2(3, 1));

        logicArena = new Arena(abilities, enemy);
        GenerateMap();
    }
    public Vector3 ParsePosition(Vector2 v)
    {
        return new Vector3(-2.5f + (int)v.x, -1.5f + (int)v.y, -0.1f);
    }

    public void GenerateMap()
    {
        //hierarchy building process
        string holderName = "Generated Map";

        //if any transformation happens just erase it all
        if (transform.FindChild(holderName))
        {
            DestroyImmediate(transform.FindChild(holderName).gameObject);
        }

        //naming our gameobject map, with holderName
        //we get its transformation
        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        //map generation process
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                //defining a new position for each tile
                Vector3 tilePosition = new Vector3(-mapSize.x / 2 + 0.5f + x, -mapSize.y / 2 + y, 0);
                //instantiate makes it come out on the editor. "as Transform" is need, like some sort of cast
                //tilePrefab can be set on editor
                //Transform newTile = Instantiate(tilePrefab, tilePosition, this.transform.rotation) as Transform;

                GameObject newTile = Instantiate(tileObj, tilePosition, this.transform.rotation) as GameObject;

                //scales the tile around its origin
                newTile.name = x.ToString() + (mapSize.y - y - 1).ToString();
                //newTile.name = x.ToString() + y.ToString();

                newTile.transform.localScale = Vector3.one * (1 - percentOutline);
                //naming the parent, the global transformation
                newTile.transform.parent = mapHolder;

            }
        }

        //initialize character and enemies
        Vector3 charPosition = ParsePosition(logicArena.character.position);
        GameObject newChar = Instantiate(character, charPosition, this.transform.rotation) as GameObject;
        newChar.name = "Player";
        character = newChar;

        Vector3 enemyPosition = ParsePosition(logicArena.enemy.position);
        GameObject newEnemy = Instantiate(enemy, enemyPosition, this.transform.rotation) as GameObject;
        newEnemy.name = "Enemy";
        enemy = newEnemy;

        //UI ELEMENTS
        //HEALTHBARS
        GameObject.Find("CharacterOrb").GetComponent<HealthBar>().TotalHp = logicArena.character.HP;
        GameObject.Find("EnemyOrb").GetComponent<HealthBar>().TotalHp = logicArena.enemy.HP;
        GameObject.Find("CharacterOrb").GetComponent<HealthBar>().CurrentHP = logicArena.character.HP;
        GameObject.Find("EnemyOrb").GetComponent<HealthBar>().CurrentHP = logicArena.enemy.HP;

        //SPELLBAR
        GameObject.Find("AbilityQ").GetComponent<Image>().overrideSprite = logicArena.character.abilityQ.icon;
        GameObject.Find("AbilityQ.CD").GetComponent<Image>().overrideSprite = logicArena.character.abilityQ.icon;
        GameObject.Find("AbilityQ.CD").GetComponent<Spell>().TotalCooldown = logicArena.character.abilityQ.cooldown;
        GameObject.Find("AbilityW").GetComponent<Image>().overrideSprite = logicArena.character.abilityW.icon;
        GameObject.Find("AbilityW.CD").GetComponent<Image>().overrideSprite = logicArena.character.abilityW.icon;
        GameObject.Find("AbilityW.CD").GetComponent<Spell>().TotalCooldown = logicArena.character.abilityW.cooldown;
        GameObject.Find("AbilityE").GetComponent<Image>().overrideSprite = logicArena.character.abilityE.icon;
        GameObject.Find("AbilityE.CD").GetComponent<Image>().overrideSprite = logicArena.character.abilityE.icon;
        GameObject.Find("AbilityE.CD").GetComponent<Spell>().TotalCooldown = logicArena.character.abilityE.cooldown;
        GameObject.Find("AbilityR").GetComponent<Image>().overrideSprite = logicArena.character.abilityR.icon;
        GameObject.Find("AbilityR.CD").GetComponent<Image>().overrideSprite = logicArena.character.abilityR.icon;
        GameObject.Find("AbilityR.CD").GetComponent<Spell>().TotalCooldown = logicArena.character.abilityR.cooldown;
    }

    void Update()
    {

        //update gamestate
        logicArena.Update();
        character.transform.position = ParsePosition(logicArena.character.position);

        //UPDATE UI
        //UPDATE HEALTHBARS
        GameObject.Find("CharacterOrb").GetComponent<HealthBar>().CurrentHP = logicArena.character.HP;
        GameObject.Find("EnemyOrb").GetComponent<HealthBar>().CurrentHP = logicArena.enemy.HP;

        //UPDATE SPELLBAR
        GameObject.Find("AbilityQ.CD").GetComponent<Spell>().remainingCooldown = logicArena.character.abilityQ.remainingCooldown;
        GameObject.Find("AbilityW.CD").GetComponent<Spell>().remainingCooldown = logicArena.character.abilityW.remainingCooldown;
        GameObject.Find("AbilityE.CD").GetComponent<Spell>().remainingCooldown = logicArena.character.abilityE.remainingCooldown;
        GameObject.Find("AbilityR.CD").GetComponent<Spell>().remainingCooldown = logicArena.character.abilityR.remainingCooldown;

        GameObject.Find("Player").GetComponent<Animator>().SetTrigger(logicArena.charAnimation);
        GameObject.Find("Enemy").GetComponent<Animator>().SetTrigger(logicArena.enemyAnimation);
        logicArena.charAnimation = "";
        logicArena.enemyAnimation = "";

        var arena = logicArena.getArena();
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                var hitbox = new Vector2(x, y);

                //if (hitbox.x > 2)
                if (arena[x,y].selfAllegiance)
                {
                    GameObject.Find(hitbox.x.ToString() + hitbox.y.ToString()).GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/Red");
                }
                else
                {
                    GameObject.Find(hitbox.x.ToString() + hitbox.y.ToString()).GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/Blue");

                }
            }
        }


        var hitboxes = logicArena.getPoolList();
        foreach (var position in hitboxes.Keys)
        {
            var set = hitboxes[position];
            foreach (var hitbox in set)
            {
                if (hitbox.active)
                {
                    if (position.x >= 0 && position.x <= 5 && (3 - position.y - 1) <= 2 && (3 - position.y - 1) >= 0)
                    {
                        GameObject.Find(position.x.ToString() + (3 - position.y - 1).ToString()).GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/Yellow");
                        Debug.Log(hitbox.active);
                    }
                }
            }
        }

        if (logicArena.enemy.HP <= 0)
        {
            DestroyImmediate(enemy);
            //endgame
            
        }


    }
}
