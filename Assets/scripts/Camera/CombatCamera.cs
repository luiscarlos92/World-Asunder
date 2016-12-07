using UnityEngine;
using System.Collections;

public class CombatCamera : MonoBehaviour {

    public Transform target;
    public float height;
    public float distance;

    private Transform _myTransform;

	// Use this for initialization
	void Start () {

        _myTransform = target;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        _myTransform.position = new Vector3(target.position.x , target.position.y + height, target.position.z - distance);
        _myTransform.LookAt(target);
	}
}
