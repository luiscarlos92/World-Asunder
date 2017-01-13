using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesUIController : MonoBehaviour {

	public LevelManager lManager;
	public Canvas abilitiesUI;

	string choosenCompanion = "Coelestine";
	string choosenSpace = "Coelestine";
	string choosenQ = "Coelestine";
	string choosenW = "Coelestine";
	string choosenE = "Coelestine";
	string choosenR = "Coelestine";

	// Use this for initialization
	void Start () {
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
						if (image.name.Contains (choosenCompanion))
							image.enabled = true;
						else
							image.enabled = false;
					}
					if (image.name.Contains (" Space ")) {
						if (image.name.Contains (choosenSpace))
							image.enabled = true;
						else
							image.enabled = false;
					}
					if (image.name.Contains (" Q ")) {
						if (image.name.Contains (choosenQ))
							image.enabled = true;
						else
							image.enabled = false;
					}
					if (image.name.Contains (" W ")) {
						if (image.name.Contains (choosenW))
							image.enabled = true;
						else
							image.enabled = false;
					}
					if (image.name.Contains (" E ")) {
						if (image.name.Contains (choosenE))
							image.enabled = true;
						else
							image.enabled = false;
					}
					if (image.name.Contains (" R ")) {
						if (image.name.Contains (choosenR))
							image.enabled = true;
						else
							image.enabled = false;
					}
				}
			}
		}
	}

	public void clickPortrait_Vriska(){
		choosenCompanion = "Vriska";
	}
	public void clickPortrait_Jonah(){
		choosenCompanion = "Jonah";
	}
	public void clickPortrait_Coelestine(){
		choosenCompanion = "Coelestine";
	}
	public void clickPortrait_Poss(){
		choosenCompanion = "Poss";
	}


	public void clickSpace_Vriska(){
		choosenSpace = "Vriska";
	}
	public void clickSpace_Jonah(){
		choosenSpace = "Jonah";
	}
	public void clickSpace_Coelestine(){
		choosenSpace = "Coelestine";
	}
	public void clickSpace_Poss(){
		choosenSpace = "Poss";
	}


	public void clickQ_Vriska(){
		choosenQ = "Vriska";
	}
	public void clickQ_Jonah(){
		choosenQ = "Jonah";
	}
	public void clickQ_Coelestine(){
		choosenQ = "Coelestine";
	}
	public void clickQ_Poss(){
		choosenQ = "Poss";
	}


	public void clickW_Vriska(){
		choosenW = "Vriska";
	}
	public void clickW_Jonah(){
		choosenW = "Jonah";
	}
	public void clickW_Coelestine(){
		choosenW = "Coelestine";
	}
	public void clickW_Poss(){
		choosenW = "Poss";
	}

	public void clickE_Vriska(){
		choosenE = "Vriska";
	}
	public void clickE_Jonah(){
		choosenE = "Jonah";
	}
	public void clickE_Coelestine(){
		choosenE = "Coelestine";
	}
	public void clickE_Poss(){
		choosenE = "Poss";
	}


	public void clickR_Vriska(){
		choosenR = "Vriska";
	}
	public void clickR_Jonah(){
		choosenR = "Jonah";
	}
	public void clickR_Coelestine(){
		choosenR = "Coelestine";
	}
	public void clickR_Poss(){
		choosenR = "Poss";
	}
}
