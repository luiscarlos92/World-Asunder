using UnityEngine;
using System.Collections;

public class PlayerSet : MonoBehaviour {
	public float positionX;
	public float positionY;
	public float backX;
	public float backY;

	private bool backtracking;

	private GameObject player;
	
	void Start() {
		//Get the player object
		player = GameObject.FindWithTag("Player");
		PlayerController pc = (PlayerController) player.GetComponent(typeof(PlayerController));
		backtracking = pc.getBacktracking();

		if(backtracking == false)
			player.transform.position = new Vector3(positionX, positionY, 0.0f);
		else
			player.transform.position = new Vector3(backX, backY, 0.0f);
	}
}