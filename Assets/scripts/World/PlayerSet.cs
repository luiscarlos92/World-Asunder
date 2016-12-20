using UnityEngine;
using System.Collections;

public class PlayerSet : MonoBehaviour {
	public float playerPositionX;
	public float playerPositionY;
	public float playerBacktrackX;
	public float playerBacktrackY;
	public float companionPositionX;
	public float companionPositionY;
	public float companionBacktrackX;
	public float companionBacktrackY;

	private bool backtracking;
	
	void Start() {
		//Get the player and companion objects
		GameObject player = GameObject.FindWithTag("Player");
		PlayerController pc = (PlayerController) player.GetComponent(typeof(PlayerController));
		backtracking = pc.getBacktracking();
		GameObject companion = GameObject.FindWithTag("Companion");

		if(backtracking == false) {
			player.transform.position = new Vector3(playerPositionX, playerPositionY, 0.0f);
			companion.transform.position = new Vector3(companionPositionX, companionPositionY, 0.0f);
		}
		else {
			player.transform.position = new Vector3(playerBacktrackX, playerBacktrackY, 0.0f);
			companion.transform.position = new Vector3(companionBacktrackX, companionBacktrackY, 0.0f);
		}
	}
}