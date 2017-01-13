using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SeaScript : MonoBehaviour {

	public LevelManager lManager;
	// Use this for initialization
	void Start () {
		lManager = (LevelManager)GameObject.Find ("LevelManager").GetComponent (typeof(LevelManager));
		lManager.events ["GoOutside"] = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
