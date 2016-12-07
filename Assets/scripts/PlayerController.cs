using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	public float speed;
	public GameObject companion;

	private int direction;
	private bool backtracking;
	private string lastArea;
	private Animator animator;
	private SpriteRenderer sprite;

	void Start() {
		animator = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();

		direction = 0;
		backtracking = false;
		lastArea = "";

		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(companion);

		//Loads starting level
		SceneManager.LoadScene("Fort");
	}
	
	void FixedUpdate() {
		Canvas DialogUI = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
		if (!DialogUI.isActiveAndEnabled) {

			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);

			transform.position += movement * speed;

			//Swap sprite
			if (moveHorizontal == 0) {
				if (moveVertical == 0) {
					//Idle
					switch (direction) {
					case 0:
						//Idle Up
						animator.Play ("player_idle_right");
						break;
					case 1:
						//Idle Down
						animator.Play ("player_idle_right");
						break;
					case 2:
						//Idle Left
						animator.Play ("player_idle_right");
						break;
					case 3:
						//Idle Up Left
						animator.Play ("player_idle_right");
						break;
					case 4:
						//Idle Down Left
						animator.Play ("player_idle_right");
						break;
					case 5:
						//Idle Right
						animator.Play ("player_idle_right");
						break;
					case 6:
						//Idle Up Right
						animator.Play ("player_idle_right");
						break;
					case 7:
						//Idle Down Right
						animator.Play ("player_idle_right");
						break;
					}
				}
				if (moveVertical > 0) {
					//Up
					direction = 0;
					animator.Play ("player_walk_up");
				}
				if (moveVertical < 0) {
					//Down
					direction = 1;
					animator.Play ("player_walk_down");
				}
			}
			if (moveHorizontal < 0) {
				if (moveVertical == 0) {
					//Left
					direction = 2;

					if (sprite.flipX == false)
						sprite.flipX = true;

					animator.Play ("player_walk_left");
				}
				if (moveVertical > 0) {
					//Up Left
					direction = 3;

					if (sprite.flipX == false)
						sprite.flipX = true;

					animator.Play ("player_walk_up_left");
				}
				if (moveVertical < 0) {
					//Down Left
					direction = 4;

					if (sprite.flipX == false)
						sprite.flipX = true;

					animator.Play ("player_walk_down_left");
				}
			}
			if (moveHorizontal > 0) {
				if (moveVertical == 0) {
					//Right
					direction = 5;

					if (sprite.flipX == true)
						sprite.flipX = false;

					animator.Play ("player_walk_right");
				}
				if (moveVertical > 0) {
					//Up Right
					direction = 6;

					if (sprite.flipX == true)
						sprite.flipX = false;

					animator.Play ("player_walk_up_right");
				}
				if (moveVertical < 0) {
					//Down Right
					direction = 7;

					if (sprite.flipX == true)
						sprite.flipX = false;

					animator.Play ("player_walk_down_right");
				}
			}
		} else {
			animator.Play ("player_idle_right");

		}
	}

	void loadSprite(string name) {
		GetComponent<SpriteRenderer>().sprite = Resources.Load(name, typeof(Sprite)) as Sprite;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Enemy")) {
			//Change to Arena Scene
		}

		if(other.gameObject.CompareTag("Poss")) {
			//Something happens?
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

	public bool getBacktracking() {
		return backtracking;
	}
}