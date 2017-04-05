using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

    public int health;
    public int experiencePoints;

    private int currentHealth;

    public AudioClip deathClip;
    public AudioClip[] zombieSounds;
    public AudioClip hitClip;
    AudioSource enemyAudio;

    private int soundRandom;

    BoxCollider boxCol;
    CapsuleCollider capCol;
    Animator anim;
    Rigidbody rBody;

	// Use this for initialization
	void Start () {
        currentHealth = health;
        enemyAudio = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();
        capCol = GetComponent<CapsuleCollider>();
        rBody = GetComponent<Rigidbody>();
        boxCol = GetComponentInChildren<BoxCollider>();

        InvokeRepeating("ZombieSounds", 0.1f, 1f);    
	}
	
	// Update is called once per frame
	void Update () {

        if ( currentHealth <= 0 )
        {
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
            PlayerExperienceManager.currentExp += experiencePoints;
            currentHealth = 999;
        }
        
        if ( currentHealth == 999)
        {
            rBody.constraints = RigidbodyConstraints.FreezeAll;
            capCol.enabled = false;
            boxCol.enabled = false;
            anim.SetTrigger("Death");
            Destroy(gameObject, 1.5f);
        }
           
	}

    public void HurtEnemy(int damage) {
        enemyAudio.clip = hitClip;
        enemyAudio.Play();
        currentHealth -= damage;
        anim.SetTrigger("Hit");
    }

    void ZombieSounds()
    {
        soundRandom = Random.Range(1, 5);

        if (soundRandom == 0 && !enemyAudio.isPlaying)
        {
            enemyAudio.clip = zombieSounds[soundRandom];
            enemyAudio.Play();
        }

        if (soundRandom == 1 && !enemyAudio.isPlaying)
        {
            enemyAudio.clip = zombieSounds[soundRandom];
            enemyAudio.Play();
        }

        if (soundRandom == 2 && !enemyAudio.isPlaying)
        {
            enemyAudio.clip = zombieSounds[soundRandom];
            enemyAudio.Play();
        }
    }
}
