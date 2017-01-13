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
		LevelManager lManager = (LevelManager)GameObject.Find ("LevelManager").GetComponent (typeof(LevelManager));
		/*GameObject player = GameObject.FindWithTag("Player");
		GameObject companion = GameObject.FindWithTag("Companion");

		if (lManager.currentScene.Equals("Fort")) {
			if (lManager.lastScene.Equals ("Cell")) {
				player.transform.position = new Vector3 (playerBacktrackX, playerBacktrackY, 0.0f);
				companion.transform.position = new Vector3 (companionBacktrackX, companionBacktrackY, 0.0f);
			}
			if (lManager.lastScene.Equals ("Beach")) {
				
			}

			if (lManager.lastScene.Equals ("Load")) {
				player.transform.position = new Vector3 (playerPositionX, playerPositionY, 0.0f);
				companion.transform.position = new Vector3 (companionPositionX, companionPositionY, 0.0f);
			}
		}

		if (lManager.currentScene.Equals ("Cell")) {
			if (lManager.lastScene.Equals ("Fort")) {
				player.transform.position = new Vector3 (playerPositionX, playerPositionY, 0.0f);
				companion.transform.position = new Vector3 (companionPositionX, companionPositionY, 0.0f);
			}
		}

		if (lManager.currentScene.Equals ("Beach")) {
			if (lManager.lastScene.Equals ("Fort")) {
				player.transform.position = new Vector3 (playerPositionX, playerPositionY, 0.0f);
				companion.transform.position = new Vector3 (companionPositionX, companionPositionY, 0.0f);
			}
		}
*/
		lManager.setPlayer ();
	}
}