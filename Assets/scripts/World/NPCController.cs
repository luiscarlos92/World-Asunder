using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPCController : MonoBehaviour {

	public Canvas bubbleCanvas;
	public string message;
	private bool dialogSpoken = false;



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
				ui.addToQueue (message);
				bubbleCanvas.enabled = false; 

				//canvas.GetComponentInChildren<Text> ().text = message;
				dialogSpoken = true;
				
		}

	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.CompareTag("Player")) {
			
		}
	}
}
