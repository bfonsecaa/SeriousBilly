using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public static float speed = 4f;
    public float lifeTime;
    public static int damage = 20;

    public static Transform bulletTransform;

    public static bool isHoming;
    public control_script enemy;

    void Start ()
    {
        bulletTransform = GetComponent<Transform>();
        enemy = FindObjectOfType<control_script>();
        isHoming = false;
    }
	
	void Update () {

        if (isHoming)
        {
            HomingBullets();
        }
        else
            transform.Translate(Vector3.forward * speed * Time.deltaTime);


        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damage);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
        }

        if (other.gameObject.tag == "Bullet")
        {
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
            return;
        }

        Destroy(gameObject);
    }

    
    void HomingBullets()
    {
        lifeTime = 3;
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }
        if (distance <= 20f)
        {
            transform.LookAt(closest.transform.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
    

