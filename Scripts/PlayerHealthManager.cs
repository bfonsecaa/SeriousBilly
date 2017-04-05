using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

    public int startHealth;
    public static int currentHealth;
    public Slider healthSlider;

    //private Renderer rend;

    AudioSource playerAudio;
    public AudioClip[] playerHit;
    private AudioClip hitClip;
    public AudioClip deathClip;
    
	// Use this for initialization
	void Start () {
        currentHealth = startHealth;
        //rend = GetComponentInChildren<Renderer>();
        playerAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    if ( currentHealth <= 0 )
        {
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            MenuController.isDead = true;
            gameObject.SetActive(false);
        }

        healthSlider.value = currentHealth;
        HealthText.health = currentHealth;
    }

    public void HurtPlayer(int damageAmount)
    {
        currentHealth -= damageAmount;

        int element = Random.Range(0, playerHit.Length);
        hitClip = playerHit[element];
        playerAudio.clip = hitClip;
        playerAudio.Play();
    }


}
