using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthText : MonoBehaviour {

    public static int health;

    Text text;

	
	void Start () {
        text = GetComponent<Text>();

        health = 100;
        text.color = Color.white;
	}   
	
	void Update () {
        text.text = "" + health;

        if (health <= 40)
        {
            text.color = Color.red;
        }
    }
}
