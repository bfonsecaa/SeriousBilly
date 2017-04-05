using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour {

    public int damageToGive;
    public float timeBetweenAttacks = 0;
    Animator anim;


    void Start ()
    {
        anim = GetComponentInParent<Animator>();
    }

	public void OnTriggerStay(Collider other)
    {
        if ( other.gameObject.tag == "Player" )
        {
            if (timeBetweenAttacks <= 0)
            {
                other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
                anim.SetBool("HitStrike", true);
                timeBetweenAttacks = 1;
            }
            timeBetweenAttacks -= Time.deltaTime;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        anim.SetBool("HitStrike", false);
        timeBetweenAttacks = 0;
    }
}
