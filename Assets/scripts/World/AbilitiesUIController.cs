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

	// Use this for initialization
	void Start () {
		abilitiesPoss.enabled = false;
		abilitiesUI.enabled = false;
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
			}
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

	public void clickPortrait_Vriska(){
		lManager.choosenCompanion = "Vriska";
	}
	public void clickPortrait_Jonah(){
		lManager.choosenCompanion = "Jonah";
	}
	public void clickPortrait_Coelestine(){
		lManager.choosenCompanion = "Coelestine";
	}
	public void clickPortrait_Poss(){
		lManager.choosenCompanion = "Poss";
	}


	public void clickSpace_Vriska(){
		lManager.choosenSpace = "Vriska";
	}
	public void clickSpace_Jonah(){
		lManager.choosenSpace = "Jonah";
	}
	public void clickSpace_Coelestine(){
		lManager.choosenSpace = "Coelestine";
	}
	public void clickSpace_Poss(){
		lManager.choosenSpace = "Poss";
	}


	public void clickQ_Vriska(){
		lManager.choosenQ = "Vriska";
	}
	public void clickQ_Jonah(){
		lManager.choosenQ = "Jonah";
	}
	public void clickQ_Coelestine(){
		lManager.choosenQ = "Coelestine";
	}
	public void clickQ_Poss(){
		lManager.choosenQ = "Poss";
	}


	public void clickW_Vriska(){
		lManager.choosenW = "Vriska";
	}
	public void clickW_Jonah(){
		lManager.choosenW = "Jonah";
	}
	public void clickW_Coelestine(){
		lManager.choosenW = "Coelestine";
	}
	public void clickW_Poss(){
		lManager.choosenW = "Poss";
	}

	public void clickE_Vriska(){
		lManager.choosenE = "Vriska";
	}
	public void clickE_Jonah(){
		lManager.choosenE = "Jonah";
	}
	public void clickE_Coelestine(){
		lManager.choosenE = "Coelestine";
	}
	public void clickE_Poss(){
		lManager.choosenE = "Poss";
	}


	public void clickR_Vriska(){
		lManager.choosenR = "Vriska";
	}
	public void clickR_Jonah(){
		lManager.choosenR = "Jonah";
	}
	public void clickR_Coelestine(){
		lManager.choosenR = "Coelestine";
	}
	public void clickR_Poss(){
		lManager.choosenR = "Poss";
	}
}
