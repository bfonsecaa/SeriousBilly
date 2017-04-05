using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerExperienceManager : MonoBehaviour {

    public static int currentExp;
    private int maxExp;
    private int spareExp;
    private int currentLevel;
    public Slider expSlider;
    public GameObject levelUpGUI;
    private AudioSource expAudio;
    public AudioClip levelUpClip;

    public static int levelUpPoints = 0;

	// Use this for initialization
	void Start () {
        currentExp = 0;
        maxExp = 50;
        currentLevel = 1;
        expAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        expSlider.value = currentExp;
        expSlider.maxValue = maxExp;

        if (currentExp >= maxExp)
        {
            levelUp();
        }
	}

    void levelUp()
    {
        currentLevel++;
        levelUpPoints++;
        LevelText.level = currentLevel;

        levelUpGUI.SetActive(true);

        expAudio.clip = levelUpClip;
        expAudio.volume = 0.2f;
        expAudio.Play();

        spareExp = currentExp - maxExp;
        currentExp = 0 + spareExp;
        maxExp = maxExp + 25;
    }
}
