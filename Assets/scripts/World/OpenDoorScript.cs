using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpenDoorScript : MonoBehaviour {

	public Canvas bubbleCanvas;
	public string message;
	public bool dialogSpoken;

	public LevelManager lManager;

	public bool sang;
	// Use this for initialization
	void Start () {
		lManager = (LevelManager)GameObject.Find ("LevelManager").GetComponent (typeof(LevelManager));
		sang = lManager.events ["Sing"];
		dialogSpoken = lManager.events ["Poss"];
		bubbleCanvas.enabled = !dialogSpoken; 
		if (lManager.events ["PossFight"] && !lManager.events ["PossCutscene"]) {
			GameObject.Find ("Cell Door").SetActive (false);
			Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
			UIController ui = (UIController)canvas.GetComponent (typeof(UIController)); 
			ui.addToQueue ("Prisoner:\"Ah, mate. You got a mean left on you...\"");
			ui.addToQueue ("Prisoner:\"But that was a nice fight. You’re not afraid to get your hands bloody like that bastard Morrissey.\"");
			ui.addToQueue ("Prisoner:\"I respect that. The name’s Poss, by the way.\"");
			ui.addToQueue ("Poss:\"I’ll be honest with you then. About Hallaway. About Sal Demar. Just... It’s all a bit surreal mate.\"");
			ui.addToQueue ("#trigger:Cutscene:Poss");
		}
		if (lManager.events ["HallawayFight"] && !lManager.events ["GoOutside"]) {
			GameObject.Find ("Cell Door").SetActive (false);
			Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
			UIController ui = (UIController)canvas.GetComponent (typeof(UIController)); 
			ui.addToQueue ("Poss:\"Bastard always had a mean undercut.\"");
			ui.addToQueue ("Hecte:\"ahah\"");
			ui.addToQueue ("Hecte:\"Huh-hum. Can agree.\"");
			ui.addToQueue ("Hecte:\"The street has have become awfully quiet, however. I don’t like this.\"");
		}

	}
	
	// Update is called once per frame
	void Update () {
	
		if ((GameObject.Find ("DialogUI").GetComponent<Canvas> () != null) && (!sang)) {
			Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
			UIController ui = (UIController)canvas.GetComponent (typeof(UIController)); 
			ui.addToQueue ("Prisoner:\"♪ ... and when came home on Friday Night, ♪\"");
			ui.addToQueue ("Prisoner:\"♪ As drunk as drunk could be, ♪\"");
			ui.addToQueue ("Prisoner:\"♪ I saw a head upon my bed, ♪\"");
			ui.addToQueue ("Prisoner:\"♪ Where my own head should be, ♪\"");
			ui.addToQueue ("Prisoner:\"♪ So I looked at my wife, and I said to her, ♪\"");
			ui.addToQueue ("Prisoner:\"♪ ‘Would you kindly tell me, ♪\"");
			ui.addToQueue ("Prisoner:\"♪ Who owns that head with you in bed, ♪\"");
			ui.addToQueue ("Prisoner:\"♪ Where my poor head should be?’ ♪\"");
			sang = true;
			lManager.events ["Sing"] = true;
		}


	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Player") && !dialogSpoken) {

			Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
			UIController ui = (UIController)canvas.GetComponent (typeof(UIController));
			bubbleCanvas.enabled = false; 
			ui.addToQueue ("Hecte:\"Nice tune.\"");
			ui.addToQueue ("Prisoner:\"If only I shared the drunkard’s state of sobriety. You are?\"");
			ui.addToQueue ("Hecte:\"Carle Hecte. Served in the Admiralty. You are the survivor?\"");
			ui.addToQueue ("Prisoner:\"Ah, today’s survivor, heh? I liked others more. You know, ‘traitor’, ‘murderer’, ‘turd gobshite’ and the like.\"");
			ui.addToQueue ("Prisoner:\"Gave off a certain sense of honesty. But I am ‘the survivor’, yes.\"");
			ui.addToQueue ("Prisoner:\"Have you come to express your deep wishes to see me swing?\"");
			ui.addToQueue ("Hecte:\"No. I came to ask you what happened at Sal Demar.\"");
			ui.addToQueue ("Prisoner:\"Straight to the point, then. Hasn’t that pubescent shite Morrissey give you the details already?\"");
			ui.addToQueue ("Coelestine:\"You are very relaxed for a man accused of murder with a death sentence on his head, no?\"");
			ui.addToQueue ("Prisoner:\"My lovely needle ear, between dying a quick death and a slow agonizing one, I’ll take the quick one any day.\"");
			ui.addToQueue ("Hecte:\"Is that what befell Captain Hallaway’s crew? A slow agonizing death?\"");
			ui.addToQueue ("Prisoner:\"What do you know about Hallaway, hun?\"");
			ui.addToQueue ("Hecte:\"I know you killed him.\"");
			ui.addToQueue ("Prisoner:\"Look at you, high and mighty. ‘Bet you think I killed him and enjoyed it, ye?!\"");
			ui.addToQueue ("Hecte:\"And did you? You killed your own officer. For all I know, you killed your own crew as well!\"");
			ui.addToQueue ("Prisoner:\"Ah, mate, you’re lucky there’s bars separating us. Otherwise, you would be eating your lying teeth right about now!\"");
			ui.addToQueue ("Hecte:\"Oh, please, don’t let that stop you. Let me see what you did to your own men!\"");

			ui.addToQueue ("#trigger:Combat:Poss");
			lManager.events ["Poss"] = true;
			dialogSpoken = true;

		}

	}
}
