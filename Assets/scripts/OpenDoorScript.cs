using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpenDoorScript : MonoBehaviour {

	public Canvas bubbleCanvas;
	public string message;
	public bool dialogSpoken = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Player") && !dialogSpoken) {

			Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
			UIController ui = (UIController)canvas.GetComponent (typeof(UIController));
			bubbleCanvas.enabled = false; 
			ui.addToQueue ("Prisoner: ... and when came home on Friday Night,");


		






			dialogSpoken = true;

		}

	}
}
