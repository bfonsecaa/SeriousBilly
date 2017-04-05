using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float speed;

    Rigidbody rBody;
    public PlayerController player;

    Vector3 startPosition;


    // Use this for initialization
    void Start () {
        rBody = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerController>();
        startPosition = this.transform.position;

        InvokeRepeating("findRotation", 2f, 3f);
    }
	
    void FixedUpdate() {

        float playerRange = Vector3.Distance(this.transform.position, player.transform.position);
        //If in range, look at player and move towards player, else move forward
        if ( playerRange <= 10f )
        {
            transform.LookAt(player.transform.position);
            rBody.velocity = (transform.forward * speed);
        } else
        {
            rBody.velocity = (transform.forward * speed);
        }
    }

    void findRotation()
    {
        float range = Vector3.Distance(this.transform.position, player.transform.position);
        //If out of range, look for a new way to face (new rotation)
        if ( range > 10f )
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            if (Physics.Raycast(transform.position, fwd, 10))
            {
                transform.rotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f);
            }
        }
    }
}
