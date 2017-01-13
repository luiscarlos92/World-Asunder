using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneUIController : MonoBehaviour {

	public LevelManager lManager;

	public Canvas cutsceneUI;
	public Image scene;

	public string name;
	public int maxScenes;
	public int currentScene = 0;

	// Use this for initialization
	void Start () {
		cutsceneUI.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space") && cutsceneUI.isActiveAndEnabled) {
			nextImage ();
		}		
	}

	public void playCutscene(string cSname){
		cutsceneUI.enabled = true;
		name = cSname;
		currentScene = 0;
		if (name.Equals ("Poss")) {
			maxScenes = 5;
		}if (name.Contains ("Adamastor")) {
			maxScenes = 3;
		}

		nextImage ();
	}

	void nextImage(){
		currentScene++;
		if (currentScene <= maxScenes) {
			Debug.Log ("cutscenes/" + name + "/" + currentScene);
			scene.sprite = Resources.Load<Sprite> ("cutscenes/" + name + "/" + currentScene);
		}
		else {
			cutsceneUI.enabled = false;
			lManager.events [name + "Cutscene"] = true;
		}
			
	}

}
