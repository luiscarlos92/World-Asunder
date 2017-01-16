using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	public LevelManager lManager;

	public float speed;

	private int direction;
	private Animator animator;
	private SpriteRenderer sprite;

	void Start() {
		animator = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();

		direction = 0;
	}
	
	void FixedUpdate() {
		
		if (!lManager.paused) {

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
		
		if(other.gameObject.CompareTag("StairsCell")) {
			lManager.loadScene("Cell");
		}

		if(other.gameObject.CompareTag("StairsFort")) {

			lManager.loadScene("Fort");
		}

		if(other.gameObject.CompareTag("Entrance") && lManager.events["HallawayFight"]) {
            GameObject.Find("Player").GetComponent<AudioSource>().clip = Resources.Load("Sound/praia") as AudioClip;
            GameObject.Find("Player").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/praia") as AudioClip, 0.5f);
            lManager.loadScene("Beach");
		}

		/*if(other.gameObject.CompareTag("ChildASpawn") && !lManager.events["ChildASpawn"]) {
			Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
			UIController ui = (UIController)canvas.GetComponent (typeof(UIController));
			ui.addToQueue ("Hecte:\"Oh, please, don’t let that stop you. Let me see what you did to your own men!\"");
			ui.addToQueue ("#trigger:Action:ChildA");
			lManager.events ["ChildASpawn"] = true;
		}

		if(other.gameObject.CompareTag("ChildBSpawn")&& !lManager.events["ChildBSpawn"]) {
			Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
			UIController ui = (UIController)canvas.GetComponent (typeof(UIController));
			ui.addToQueue ("Hecte:\"Oh, please, don’t let that stop you. Let me see what you did to your own men!\"");
			ui.addToQueue ("#trigger:Action:ChildB");
			lManager.events ["ChildBSpawn"] = true;
		}
*/
		if(other.gameObject.CompareTag("ChildBSpawn")&& !lManager.events["AdamastorSpawn"]) {

			Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
			UIController ui = (UIController)canvas.GetComponent (typeof(UIController)); 

			ui.addToQueue ("Adamastor:\"I hunger! I thirst!\"");
			ui.addToQueue ("#trigger:Action:Adamastor");

			lManager.events ["AdamastorSpawn"] = true;
		}
	}

}