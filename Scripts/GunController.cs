using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

    public bool isFiring;
    public BulletController bullet;
    AudioSource gunShot;

    public float speed;
    public static float reloadTime;
    private float shotCounter;

    public Transform firePoint;

    Animator anim;

    Light gunLight;
    float lightTimer;

    ParticleSystem gunParticles;

	// Use this for initialization
	void Start () {
        gunShot = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        anim = GetComponentInParent<Animator>();
        gunParticles = GetComponent<ParticleSystem>();

        lightTimer = 1;
        reloadTime = 1f;
    }
	
	// Update is called once per frame
	void Update () {

        shotCounter -= Time.deltaTime;
        lightTimer -= Time.deltaTime;

        if ( isFiring && shotCounter <= 0 && Time.timeScale == 1 && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() )
        {
            shotCounter = reloadTime;
            gunShot.Play();
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            newBullet.transform.localScale = StatController.sizeVector;
            anim.SetTrigger("Shoot");
            gunLight.enabled = true;
            lightTimer = 0.1f;

            gunParticles.Stop();
            gunParticles.Play();
        }

        if ( lightTimer <= 0 )
        {
            gunLight.enabled = false;
        }

	}
}
