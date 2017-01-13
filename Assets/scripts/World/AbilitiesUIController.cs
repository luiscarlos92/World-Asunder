using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesUIController : MonoBehaviour {

	public LevelManager lManager;
	public Canvas abilitiesUI;

	public Canvas abilitiesVriska;
	public Canvas abilitiesJonah;
	public Canvas abilitiesCoelestine;
	public Canvas abilitiesPoss;

	public Text ATitle;
	public Text AName;
	public Text ADescription;

	public Canvas message;

	// Use this for initialization
	void Start () {
		message.enabled = false;
		abilitiesPoss.enabled = false;
		abilitiesUI.enabled = false;
		ATitle.enabled = false;
		AName.enabled = false;
		ADescription.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("tab")) {
			if (!abilitiesUI.isActiveAndEnabled) {
				abilitiesUI.enabled = true;
				lManager.paused = true;
			} else {
				abilitiesUI.enabled = false;
				lManager.paused = false;

				CompanionController comp = (CompanionController) GameObject.FindGameObjectWithTag ("Companion").GetComponent (typeof(CompanionController)); 
				comp.changeCompanion (lManager.choosenCompanion);
			}
		}

		if (Input.GetKeyDown ("space") && message.isActiveAndEnabled) {
			message.enabled = false;
		}

		if (abilitiesUI.isActiveAndEnabled) {
			

			Image[] images = abilitiesUI.GetComponentsInChildren<Image> ();

			foreach (Image image in images) {
				if (image.name.Contains ("Frame")) {
					if (image.name.Contains (" Companion ")) {
						if (image.name.Contains (lManager.choosenCompanion))
							image.enabled = true;
						else
							image.enabled = false;
					}
					if (image.name.Contains (" Space ")) {
						if (image.name.Contains (lManager.choosenSpace)) 
							image.enabled = true;
						else
							image.enabled = false;
					}
					if (image.name.Contains (" Q ")) {
						if (image.name.Contains (lManager.choosenQ))
							image.enabled = true;
						else
							image.enabled = false;
					}
					if (image.name.Contains (" W ")) {
						if (image.name.Contains (lManager.choosenW))
							image.enabled = true;
						else
							image.enabled = false;
					}
					if (image.name.Contains (" E ")) {
						if (image.name.Contains (lManager.choosenE))
							image.enabled = true;
						else
							image.enabled = false;
					}
					if (image.name.Contains (" R ")) {
						if (image.name.Contains (lManager.choosenR))
							image.enabled = true;
						else
							image.enabled = false;
					}
				}
			}
		}
	}

	public void displayInfo(){

		ATitle.enabled = true;
		AName.enabled = true;
		ADescription.enabled = true;
	}

	public void clickPortrait_Vriska(){
		lManager.choosenCompanion = "Vriska";
	}
	public void clickPortrait_Jonah(){
		lManager.choosenCompanion = "Jonah";
	}
	public void clickPortrait_Coelestine(){
		lManager.choosenCompanion = "Coelestine";
		ATitle.text = "Bodyguard";
		AName.text = "Coelestine";
		ADescription.text = "Hotheaded";
		displayInfo ();
	}
	public void clickPortrait_Poss(){
		lManager.choosenCompanion = "Poss";
		ATitle.text = "Bodyguard";
		AName.text = "Poss";
		ADescription.text = "...";
		displayInfo ();
	}


	public void clickSpace_Vriska(){
		lManager.choosenSpace = "Vriska";
	}
	public void clickSpace_Jonah(){
		lManager.choosenSpace = "Jonah";
	}
	public void clickSpace_Coelestine(){
		lManager.choosenSpace = "Coelestine";
		ATitle.text = "Space";
		AName.text = "Poison Dagger";
		ADescription.text = "Throws a poisoned dagger at your enemy, dealing damage over time.";
		displayInfo ();
	}
	public void clickSpace_Poss(){
		lManager.choosenSpace = "Poss";
		ATitle.text = "Space";
		AName.text = "Sleight of Hand";
		ADescription.text = "Shoots a quick bullet for small damage";
		displayInfo ();
	}


	public void clickQ_Vriska(){
		lManager.choosenQ = "Vriska";
	}
	public void clickQ_Jonah(){
		lManager.choosenQ = "Jonah";
	}
	public void clickQ_Coelestine(){
		lManager.choosenQ = "Coelestine";
		ATitle.text = "Q";
		AName.text = "Backstab";
		ADescription.text = "Cuts your enemy in the back 2 squares forward.";
		displayInfo ();
	}
	public void clickQ_Poss(){
		lManager.choosenQ = "Poss";
		ATitle.text = "Q";
		AName.text = "Torrent";
		ADescription.text = "Summon sea currents 3 squares away to surprise your enemy, and stop them in their tracks.";
		displayInfo ();
	}


	public void clickW_Vriska(){
		lManager.choosenW = "Vriska";
	}
	public void clickW_Jonah(){
		lManager.choosenW = "Jonah";
	}
	public void clickW_Coelestine(){
		lManager.choosenW = "Coelestine";
		ATitle.text = "W";
		AName.text = "Invisibility";
		ADescription.text = "...";
		displayInfo ();
	}
	public void clickW_Poss(){
		lManager.choosenW = "Poss";
		ATitle.text = "W";
		AName.text = "Dirty Tricks";
		ADescription.text = "Shoots a sucker bullet dealing damage and stunning your enemy.";
		displayInfo ();
	}

	public void clickE_Vriska(){
		lManager.choosenE = "Vriska";
	}
	public void clickE_Jonah(){
		lManager.choosenE = "Jonah";
	}
	public void clickE_Coelestine(){
		lManager.choosenE = "Coelestine";
		ATitle.text = "E";
		AName.text = "Smoke Bomb";
		ADescription.text = "Summon sea currents to blow your enemy and deal damage 3 squares away.";
		displayInfo ();
	}
	public void clickE_Poss(){
		lManager.choosenE = "Poss";
		ATitle.text = "E";
		AName.text = "Cannon Barrage";
		ADescription.text = "...";
		displayInfo ();
	}


	public void clickR_Vriska(){
		lManager.choosenR = "Vriska";
	}
	public void clickR_Jonah(){
		lManager.choosenR = "Jonah";
	}
	public void clickR_Coelestine(){
		lManager.choosenR = "Coelestine";
		ATitle.text = "R";
		AName.text = "Garrote";
		ADescription.text = "Traps the enemy in front of you, and deals damage over time.";
		displayInfo ();
	}
	public void clickR_Poss(){
		lManager.choosenR = "Poss";
		ATitle.text = "R";
		AName.text = "Caravel";
		ADescription.text = "Throws a Lusitanian Caravel at your enemy dealing damage.";
		displayInfo ();
	}
}
