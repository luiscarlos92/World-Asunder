 using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SeaScript : MonoBehaviour {

	public LevelManager lManager;
	// Use this for initialization
	void Start () {
		lManager = (LevelManager)GameObject.Find ("LevelManager").GetComponent (typeof(LevelManager));

		Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
		UIController ui = (UIController)canvas.GetComponent (typeof(UIController)); 

		if (!lManager.events ["GoOutside"]) {
			if (lManager.choosenCompanion.Equals ("Poss")) {
				ui.addToQueue ("Poss:\"Oh lovely! A jolly tune to warm up these grizzly old bones, ye?\"");
				ui.addToQueue ("Poss:\"I suggest we search the water. Pounce on these lasses before they pounce on us.\"");
			}
			if (lManager.choosenCompanion.Equals ("Coelestine")) {
				ui.addToQueue ("Coelestine:\"A song for the dead or of the dead? It remains to be seen...\"");
				ui.addToQueue ("Coelestine:\"A sirens call from the unnatural sea. We should stop them before they enchant us beyond thought.\"");
			}
		}
		lManager.events ["GoOutside"] = true;

		if (lManager.events["AdamastorFight"] && !lManager.events["Choice"]) {
			GameObject newEnemy = Instantiate(lManager.adamastordefeatedPrefab, ((GameObject.Find ("Player").transform.position + GameObject.Find ("AdamastorSpawn").transform.position)/2), this.transform.rotation) as GameObject;
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (lManager.events ["Spawn2Fight"] && !lManager.events ["AdamastorSpawn"]) {

			Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
			UIController ui = (UIController)canvas.GetComponent (typeof(UIController)); 

			ui.addToQueue ("Adamastor:\"I hunger! I thirst!\"");
			ui.addToQueue ("#trigger:Action:Adamastor");

			lManager.events ["AdamastorSpawn"] = true;
		}

		if (lManager.events ["AdamastorFight"] && !lManager.events ["Choice"]) {

			Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
			UIController ui = (UIController)canvas.GetComponent (typeof(UIController)); 

			ui.addToQueue ("Adamastor:\"No! No, no, no! Please, please MERCY! I did not wish it! He told me to, his words were my thoughts.\"");
			ui.addToQueue ("Adamastor:\"Please don’t take me from me. I am me, it’s all I am. PLEASE!!\"");
			ui.addToQueue ("#trigger:Action:Choice");


			lManager.events ["Choice"] = true;
		}

	}




}
