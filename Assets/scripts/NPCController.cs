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
		if(other.gameObject.CompareTag("Player")) {

				Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
				canvas.enabled = true;
				canvas.GetComponentInChildren<Text> ().text = message;
				dialogSpoken = true;
				bubbleCanvas.enabled = false; 
		}

	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.CompareTag("Player")) {
			
		}
	}
}
