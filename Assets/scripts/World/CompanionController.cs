using UnityEngine;
using System.Collections;

public class CompanionController : MonoBehaviour {

	Transform target; //the enemy's target
	float moveSpeed = 1.5f; //move speed
	float maxDistance = 1;
	float range;
	Transform myTransform; //current transform data of this enemy


	void Awake()
	{
		myTransform = transform; //cache transform data for easy access/preformance
	}


	void Start()
	{
		target = GameObject.FindWithTag("Player").transform; //target the player
	}


	void Update () {
		

		//move towards the player
		//myTransform.position += target.position * moveSpeed * Time.deltaTime;

		range = Vector2.Distance (transform.position, target.position);

		if (range > maxDistance) {

			transform.position = Vector2.MoveTowards (transform.position, target.position, moveSpeed * Time.deltaTime);
		}
	}


}
