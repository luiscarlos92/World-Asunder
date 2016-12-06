using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	public Canvas dialogUI;
	public Text npcTextBox;

	// Use this for initialization
	void Start () {
		npcTextBox.text = "Olá eu sou noob!";
		dialogUI.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space") && dialogUI.isActiveAndEnabled) {
			dialogUI.enabled = false;
		}
					


	}
}
