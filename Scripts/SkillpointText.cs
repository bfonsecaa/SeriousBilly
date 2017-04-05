using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillpointText : MonoBehaviour {

    public static int skillpoints;

    Text text;


    void Start()
    {
        text = GetComponent<Text>();

        skillpoints = 0;
        text.color = Color.white;
    }

    void Update()
    {
        skillpoints = PlayerExperienceManager.levelUpPoints;
        text.text = "Skillpoints: " + skillpoints;
    }
}
