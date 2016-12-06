using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public Canvas dialogUI;
	public float speed;

	private int direction;
	private bool backtracking;
	private string lastArea;

	private bool npcColliding = false;
	private Collider2D collidingObject;

	void Start() {
		direction = 0;
		backtracking = false;
		lastArea = "";

		DontDestroyOnLoad(gameObject);

		//Loads starting level
		SceneManager.LoadScene("Fort");

	}
	
	void FixedUpdate() {
		dialogUI = GameObject.Find ("DialogUI").GetComponent<Canvas>();

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

		transform.position += movement * speed;

		//Swap sprite
		if(moveHorizontal == 0) {
			if(moveVertical == 0) {
				//Idle
				switch(direction) {
					case 0:
						loadSprite ("spr_idle_up_0");
						break;
					case 1:
						loadSprite("spr_idle_down_0");
						break;
					case 2:
						loadSprite("spr_idle_left_0");
						break;
					case 3:
						loadSprite("spr_idle_up_left_0");
						break;
					case 4:
						loadSprite("spr_idle_down_left_0");
						break;
					case 5:
						loadSprite("spr_idle_right_0");
						break;
					case 6:
						loadSprite("spr_idle_up_right_0");
						break;
					case 7:
						loadSprite("spr_idle_down_right_0");
						break;
				}
			}
			if(moveVertical > 0) {
				direction = 0;
				loadSprite("spr_up_0");
			}
			if(moveVertical < 0) {
				direction = 1;
				loadSprite("spr_down_0");
			}
		}
		if(moveHorizontal < 0) {
			if(moveVertical == 0) {
				direction = 2;
				loadSprite("spr_left_0");
			}
			if(moveVertical > 0) {
				direction = 3;
				loadSprite("spr_up_left_0");
			}
			if(moveVertical < 0) {
				direction = 4;
				loadSprite("spr_down_left_0");
			}
		}
		if(moveHorizontal > 0) {
			if(moveVertical == 0) {
				direction = 5;
				loadSprite("spr_right_0");
			}
			if(moveVertical > 0) {
				direction = 6;
				loadSprite("spr_up_right_0");
			}
			if(moveVertical < 0) {
				direction = 7;
				loadSprite("spr_down_right_0");
			}
		}
			


	}

	void loadSprite(string name) {
		GetComponent<SpriteRenderer>().sprite = Resources.Load(name, typeof(Sprite)) as Sprite;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Enemy")) {
			npcColliding = true;
			collidingObject = other;
		}

		if(other.gameObject.CompareTag("Companion")) {
			//Something happens?
			npcColliding = true;
			//dialogUI.enabled = true;
			collidingObject = other;
		}

		if(other.gameObject.CompareTag("Entrance")) {
			//Change to Entrance Scene
		}

		if(other.gameObject.CompareTag("StairsCell")) {
			backtracking = false;
			lastArea = "Cell";

			//Change to Cell Scene
			SceneManager.LoadScene("Cell");
		}

		if(other.gameObject.CompareTag("StairsFort")) {
			if(lastArea == "Cell")
				backtracking = true;
			else
				backtracking = false;
			
			lastArea = "Fort";

			//Change to Fort Scene
			SceneManager.LoadScene("Fort");
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.CompareTag("Enemy")) {
			//Change to Arena Scene
			npcColliding = false;
			collidingObject = null;
		}

		if(other.gameObject.CompareTag("Companion")) {
			//Something happens?
			//dialogUI.enabled = false;
			npcColliding = false;
			collidingObject = null;
		}

		if(other.gameObject.CompareTag("Entrance")) {
			//Change to Entrance Scene

		}

		if(other.gameObject.CompareTag("StairsCell")) {
			
		}

		if(other.gameObject.CompareTag("StairsFort")) {
			
		}
	}

	public bool getBacktracking() {
		return backtracking;
	}
}