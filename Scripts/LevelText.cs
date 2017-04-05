using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelText : MonoBehaviour {

    public static int level;

    Text text;

	void Start () {
        text = GetComponent<Text>();
        level = 1;
    }
	
	
	void Update () {
        text.text = "Level " + level;
	}
}
