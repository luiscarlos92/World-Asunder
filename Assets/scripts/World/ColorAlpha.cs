using UnityEngine;
using System.Collections;

public class ColorAlpha : MonoBehaviour {	
	void Start() {
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		sprite.color = new Color (1.0f, 1.0f, 1.0f, 0.25f);
	}
}