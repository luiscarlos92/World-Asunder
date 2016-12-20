using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public float TotalHp;
    public float CurrentHP;
    public Image orb;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        orb.fillAmount =  (CurrentHP / TotalHp);
        //Debug.Log(CurrentHP + "/" + TotalHp + "/" + orb);
        
	}
}
