using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class YouAchieved : MonoBehaviour
{

    public static int endingLevel;

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        endingLevel = 1;
    }

    void Update()
    {
        text.text = "You achieved level " + endingLevel + "!";
    }
}