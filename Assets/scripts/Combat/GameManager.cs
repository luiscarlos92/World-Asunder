using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public LevelManager lManager;

    //MAP RELATED
    //change tile to a tileclass that has a sprite animation
    public GameObject tileObj;
    public Vector2 mapSize = new Vector2(6, 3);
    //tile separation factor
    private float percentOutline = 0.07f;
    public GameObject[,] arena;
    public Arena logicArena;

    //CHANGEABLE PARAMETERS

    public GameObject character;
    public GameObject enemy;
    public Ability[] characterAbilities = new Ability[5];
    public Ability[] enemyAbilities = new Ability[5];

    public Character Hecte;
    public Enemy Poss;
    public Enemy Hallaway;
    public Enemy Adamastor;
    public Enemy spawn1;
    public Enemy spawn2;

    public List<Enemy> chars;

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
        lManager = (LevelManager)GameObject.Find("LevelManager").GetComponent(typeof(LevelManager));

        chars = new List<Enemy>();
        arena = new GameObject[6, 3];
        ////////////////////////////////////////////////////////////////////////////////////
        //CHARACTER
		//setPlayerAbilities();
        characterAbilities[0] = new BasicShot();
        characterAbilities[1] = new Sword();
        characterAbilities[2] = new CannonBarrage();
        characterAbilities[3] = new SmokeBomb();
        characterAbilities[4] = new Caravel();
        Hecte = new Character("Hecte", characterAbilities);
        Hecte.spritePath = "Animations/AnimatedCharacters/Hecte";

        //ENEMIES
        //POSS
        enemyAbilities[0] = new SleightOfHand();
        enemyAbilities[1] = new Torrent();
        enemyAbilities[2] = new DirtyTricks();
        enemyAbilities[3] = new CannonBarrage();
        enemyAbilities[4] = new Caravel();
        Poss = new Enemy("Poss", enemyAbilities);
        Poss.spritePath = "Animations/AnimatedCharacters/Poss";

        //HALLAWAY
        enemyAbilities[0] = new SleightOfHand();
        enemyAbilities[1] = new DirtyTricks();
        enemyAbilities[2] = new Sword();
        enemyAbilities[3] = new WideSword();
        enemyAbilities[4] = new LongSword();
        Hallaway = new Enemy("Hallaway", enemyAbilities);
        Hallaway.spritePath = "Animations/AnimatedCharacters/Hallaway";

        //spawn
        enemyAbilities[0] = new DirtyTricks();
        enemyAbilities[1] = new DirtyTricks();
        enemyAbilities[2] = new DirtyTricks();
        enemyAbilities[3] = new DirtyTricks();
        enemyAbilities[4] = new DirtyTricks();
        spawn1 = new Enemy("Spawn1", enemyAbilities);
        spawn1.spritePath = "Animations/AnimatedCharacters/Spawn";

        //spawn
        enemyAbilities[0] = new DirtyTricks();
        enemyAbilities[1] = new DirtyTricks();
        enemyAbilities[2] = new DirtyTricks();
        enemyAbilities[3] = new DirtyTricks();
        enemyAbilities[4] = new DirtyTricks();
        spawn2 = new Enemy("Spawn2", enemyAbilities);
        spawn2.spritePath = "Animations/AnimatedCharacters/Spawn";
        //ADAMAS
        enemyAbilities[0] = new Torrent();
        enemyAbilities[1] = new DirtyTricks();
        enemyAbilities[2] = new Torrent();
        enemyAbilities[3] = new DirtyTricks();
        enemyAbilities[4] = new Torrent();
        Enemy Adamastor = new Enemy("Adamastor", enemyAbilities);
        Adamastor.spritePath = "Animations/AnimatedCharacters/Adamastor";

        chars.Add(Poss);
        chars.Add(Hallaway);
        chars.Add(Adamastor);
        chars.Add(spawn1);
        chars.Add(spawn2);

        //  load character and enemy based on string used by PlayerPrefs.
        // so I have to instantiate everything here

        Enemy teki = Adamastor;

        foreach (var entry in chars)
        {
            //Debug.Log (entry.name + " " + lManager.enemy);
            if (entry.name == lManager.enemy)
            {
                teki = entry;
                Debug.Log(entry.name + " " + lManager.enemy);
            }
        }
        logicArena = new Arena(Hecte,teki);
        Debug.Log("cenas");
        ////////////////////////////////////////////////////////////////////////////////////
        //Sprite bg = Resources.Load<Sprite>("Sprites/Background/background");
        //GameObject.Find("Background").GetComponent<Image>().sprite = bg;
        GenerateMap();
        AudioSource audio = GameObject.Find("Map").AddComponent<AudioSource>();
        AudioClip loop = Resources.Load<AudioClip>("Sound/adamastor2");
        audio.PlayOneShot(loop, 0.5f);
        
    }

	public void setPlayerAbilities(){
		//SPACE
		if (lManager.choosenSpace == "Vriska")
			characterAbilities[0] = new PoisonDagger();
		if (lManager.choosenSpace == "Jonah")
			characterAbilities[0] = new PoisonDagger();
		if (lManager.choosenSpace == "Coelestine")
			characterAbilities[0] = new PoisonDagger();
		if (lManager.choosenSpace == "Poss")
			characterAbilities[0] = new SleightOfHand();

		//Q
		if (lManager.choosenSpace == "Vriska")
			characterAbilities[1] = new PoisonDagger();
		if (lManager.choosenSpace == "Jonah")
			characterAbilities[1] = new PoisonDagger();
		if (lManager.choosenSpace == "Coelestine")
			characterAbilities[1] = new Backstab();
		if (lManager.choosenSpace == "Poss")
			characterAbilities[1] = new Torrent();

		//W
		if (lManager.choosenSpace == "Vriska")
			characterAbilities[2] = new PoisonDagger();
		if (lManager.choosenSpace == "Jonah")
			characterAbilities[2] = new PoisonDagger();
		if (lManager.choosenSpace == "Coelestine")
			characterAbilities[2] = new WideSword();
		if (lManager.choosenSpace == "Poss")
			characterAbilities[2] = new DirtyTricks();

		//E
		if (lManager.choosenSpace == "Vriska")
			characterAbilities[3] = new PoisonDagger();
		if (lManager.choosenSpace == "Jonah")
			characterAbilities[3] = new PoisonDagger();
		if (lManager.choosenSpace == "Coelestine")
			characterAbilities[3] = new SmokeBomb();
		if (lManager.choosenSpace == "Poss")
			characterAbilities[3] = new LongSword();

		//R
		if (lManager.choosenSpace == "Vriska")
			characterAbilities[4] = new PoisonDagger();
		if (lManager.choosenSpace == "Jonah")
			characterAbilities[4] = new PoisonDagger();
		if (lManager.choosenSpace == "Coelestine")
			characterAbilities[4] = new Garrote();
		if (lManager.choosenSpace == "Poss")
			characterAbilities[4] = new Caravel();
		
	}

    public Vector3 ParsePosition(Vector2 v)
    {
        return new Vector3(-2.5f + (int)v.x, -1.5f + (int)v.y, -0.1f);
    }

    public void SetParameters(Arena arena)
    {
        logicArena = arena;
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
        character = Resources.Load(logicArena.character.spritePath) as GameObject;
        GameObject newChar = Instantiate(character, charPosition, this.transform.rotation) as GameObject;
        newChar.name = "Player";
        character = newChar;

        Vector3 enemyPosition = ParsePosition(logicArena.enemy.position);
		Debug.Log (logicArena.enemy.name);
        enemy = Resources.Load(logicArena.enemy.spritePath) as GameObject;
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
        GameObject.Find("Passive").GetComponent<Image>().overrideSprite = logicArena.character.passive.icon;
        GameObject.Find("Passive.CD").GetComponent<Image>().overrideSprite = logicArena.character.passive.icon;
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
		enemy.transform.position = ParsePosition (logicArena.enemy.position);

        //UPDATE UI
        //UPDATE HEALTHBARS
        GameObject.Find("CharacterOrb").GetComponent<HealthBar>().CurrentHP = logicArena.character.HP;
        GameObject.Find("EnemyOrb").GetComponent<HealthBar>().CurrentHP = logicArena.enemy.HP;

        //UPDATE SPELLBAR
        GameObject.Find("Passive.CD").GetComponent<Spell>().remainingCooldown = logicArena.character.passive.remainingCooldown;
        GameObject.Find("AbilityQ.CD").GetComponent<Spell>().remainingCooldown = logicArena.character.abilityQ.remainingCooldown;
        GameObject.Find("AbilityW.CD").GetComponent<Spell>().remainingCooldown = logicArena.character.abilityW.remainingCooldown;
        GameObject.Find("AbilityE.CD").GetComponent<Spell>().remainingCooldown = logicArena.character.abilityE.remainingCooldown;
        GameObject.Find("AbilityR.CD").GetComponent<Spell>().remainingCooldown = logicArena.character.abilityR.remainingCooldown;

        GameObject.Find("Player").GetComponent<Animator>().SetTrigger(logicArena.charAnimation);
        GameObject.Find("Enemy").GetComponent<Animator>().SetTrigger(logicArena.enemyAnimation);

        if (logicArena.character.Stunned)
        {
            GameObject.Find("Player").GetComponent<Animator>().SetTrigger("Hurt");
            if (logicArena.character.StunnedFrames % 2 == 0)
                GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
            else
                GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = true;
        }
        else
            GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = true;

        if (logicArena.enemy.Stunned)
        {
            GameObject.Find("Enemy").GetComponent<Animator>().SetTrigger("Hurt");
            if (logicArena.enemy.StunnedFrames % 2 == 0)
                GameObject.Find("Enemy").GetComponent<SpriteRenderer>().enabled = false;
            else
                GameObject.Find("Enemy").GetComponent<SpriteRenderer>().enabled = true;
        }
        else
            GameObject.Find("Enemy").GetComponent<SpriteRenderer>().enabled = true;

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
					GameObject.Find(hitbox.x.ToString() + hitbox.y.ToString()).GetComponent<MeshRenderer>().material = Resources.Load("Material/Blue") as Material;

                }
            }
        }


        var hitboxes = logicArena.getPoolList();
        foreach (var position in hitboxes.Keys)
        {
            var set = hitboxes[position];
            foreach (var hitbox in set)
            {
                //if (hitbox.active)
                //{
                    if (position.x >= 0 && position.x <= 5 && (3 - position.y - 1) <= 2 && (3 - position.y - 1) >= 0)
                    {
                        GameObject.Find(position.x.ToString() + (3 - position.y - 1).ToString()).GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material/Yellow");
                    //                        Debug.Log(hitbox.active);
                    GameObject prefab = Resources.Load(hitbox.ability.preFab) as GameObject;
                    foreach (var cena in hitbox.ability.particleDest)
                    {
                        GameObject PARTICLE = Instantiate(prefab, ParsePosition(cena), this.transform.rotation);
                    }
                    }
                //}
            }
        }

        if (logicArena.enemy.HP <= 0)
        {
			lManager.returnCombatArena ();
         //   SceneManager.LoadScene("CombatArena");
        }
        if(logicArena.character.HP <= 0)
        {
            lManager.restartGame();
        }


    }
}