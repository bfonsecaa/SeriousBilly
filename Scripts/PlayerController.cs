using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public static float speed = 3f;

    Rigidbody rBody;
    
    Vector3 moveInput;
    Vector3 moveVelocity;

    RaycastHit hit;
    
    Camera mainCamera;

    public GunController gun;

    Animator anim;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * speed;
        

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (ground.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if (Input.GetMouseButtonDown(0))
        {
            gun.isFiring = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            gun.isFiring = false;
        }
    }

    void FixedUpdate () {

        rBody.velocity = moveVelocity;

        if (rBody.velocity.magnitude > 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
