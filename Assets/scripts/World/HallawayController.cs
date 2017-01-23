using UnityEngine;
using UnityEngine.UI;
using System.Collections; 
using System.Collections.Generic;
using System;
public class HallawayController : MonoBehaviour {

	public LevelManager lManager;

	Transform target; //the enemy's target
	public float moveSpeed = 2f; //move speed
	float maxDistance = 1;
	float triggerDistance = 2.5f;
	float range;
	Transform myTransform; //current transform data of this enemy
	bool triggered = false;

	void Awake()
	{
		myTransform = transform; //cache transform data for easy access/preformance
	}
	// Use this for initialization
	void Start () {
		lManager = (LevelManager)GameObject.Find ("LevelManager").GetComponent (typeof(LevelManager));
		target = GameObject.FindWithTag("Player").transform; //target the player
	}
	
	// Update is called once per frame
	void Update () {

		//move towards the player
		//myTransform.position += target.position * moveSpeed * Time.deltaTime;

		range = Vector2.Distance (transform.position, target.position);



		if (range > maxDistance) {
			if((range < triggerDistance) && (!triggered)){
				Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
				UIController ui = (UIController)canvas.GetComponent (typeof(UIController)); 
				ui.addToQueue ("Poss:\"Bitch born!\"");
				ui.addToQueue ("Coelestine:\"Friend of yours?\"");
				ui.addToQueue ("Poss:\"Hallaway! How?!\"");
				ui.addToQueue ("Hecte:\"I don’t know, but I don’t think he wants to be asked.\"");
				ui.addToQueue ("Poss:\"You’re not doing this alone, ye hear! It wouldn’t be right! ‘Tis my battle here, ye!\"");
				ui.addToQueue ("#trigger:Action:Poss");
				triggered = true;
			}else {
				if (!lManager.paused) {
					transform.position = Vector2.MoveTowards (transform.position, target.position, moveSpeed * Time.deltaTime);
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Player")) {
			Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
			UIController ui = (UIController)canvas.GetComponent (typeof(UIController)); 

			if(lManager.choosenCompanion.Equals("Poss"))
				ui.addToQueue ("Poss:\"Up and away ye.\"");
			if(lManager.choosenCompanion.Equals("Coelestine"))
				ui.addToQueue ("Coelestine:\"So be it.\"");
			
			ui.addToQueue ("#trigger:Combat:Hallaway");
		}

	}
}
