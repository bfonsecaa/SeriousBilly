using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    public GameObject pausePanel;
    public GameObject pauseText;


	void Start () {
        offset = transform.position - player.transform.position;
        Time.timeScale = 1;
	}
	
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}

    void Update()
    {
        if ( Input.GetKeyDown("escape") )
        {
            if (Time.timeScale == 1)
            {
                showPauseMenu();
            }
            else if (Time.timeScale == 0)
            {
                hidePauseMenu();
            }
        }
        
    }

    void showPauseMenu()
    {
        Time.timeScale = 0;
        pauseText.SetActive(true);
        pausePanel.SetActive(true);
    }

    public void hidePauseMenu()
    {
        Time.timeScale = 1;
        pauseText.SetActive(false);
        pausePanel.SetActive(false);
    }

}
