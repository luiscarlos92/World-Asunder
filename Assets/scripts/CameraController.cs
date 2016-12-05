using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public float backgroundXLimit;
	public float backgroundYLimit;

	private GameObject player;

	void Start() {
		//Get the player object
		player = GameObject.FindWithTag("Player");
	}

	void LateUpdate() {
		Vector3 camPosition = player.transform.position;
		camPosition.z = -10.0f;

		//Limits camera position to background limits
		if(camPosition.x > backgroundXLimit)
			camPosition.x = backgroundXLimit;
		
		if(camPosition.x < -backgroundXLimit)
			camPosition.x = -backgroundXLimit;
		
		if(camPosition.y > backgroundYLimit)
			camPosition.y = backgroundYLimit;
		
		if(camPosition.y < -backgroundYLimit)
			camPosition.y = -backgroundYLimit;
		
		transform.position = camPosition;
	}
}