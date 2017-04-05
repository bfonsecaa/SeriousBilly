using UnityEngine;
using System.Collections;

// Had this setup for future multiple enemies
public class SpawnController : MonoBehaviour {

    public GameObject[] enemy;
    public float spawnTime = 5;
    private float playerRange;
    private int rndNum;

    public PlayerController player;

    void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        player = FindObjectOfType<PlayerController>();
    }
	
	void Update ()
    {
        playerRange = Vector3.Distance(this.transform.position, player.transform.position);
        rndNum = Random.Range(0, 2); // Randomize spawning a little more
    }

	void Spawn () {

        if (playerRange >= 15f && PlayerHealthManager.currentHealth > 0 && rndNum == 1)
        {
            int enemyIndex = Random.Range(0, enemy.Length);
            Instantiate(enemy[enemyIndex], transform.position, transform.rotation);
        }
	}
}
