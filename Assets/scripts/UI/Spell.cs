using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spell : MonoBehaviour {

    public float remainingCooldown = 0;
    public float TotalCooldown;
    public Image icon;

	// Update is called once per frame
	void Update () {
        //Debug.Log("Hey im spell " + icon.name + (1 - (remainingCooldown / TotalCooldown)));
        icon.fillAmount = (1 - remainingCooldown / TotalCooldown);
	}
}
