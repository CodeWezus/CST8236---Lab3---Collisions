using UnityEngine;
using System.Collections;

public class ApplyMotion : MonoBehaviour {


    // Bullet movement speed
    public float ballSpeed = 100.0f;
    public ParticleSystem destructionEmitter;
    public ParticleSystem Destruction;

    // The ridgidbody of the bullet
    private Rigidbody bulletBody = null;
    private Renderer rend = null;
    private Light bulletLight = null;

	// Use this for initialization
	void Start () {
        bulletBody = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        bulletLight = GetComponent<Light>();
        destructionEmitter = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        // Get X or Y axis input
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        // Get movement cords
        float moveX = inputX * ballSpeed * Time.deltaTime;
        float moveZ = inputZ * ballSpeed * Time.deltaTime;

        //Move bullet
        bulletBody.AddForce(moveX, 0f, moveZ);
	}

    // Activates when the bullet collides with an object
    public void OnCollisionEnter(Collision col)
    {

        // If colliding with anything but the floor change color.
        if (!col.gameObject.name.Equals("Floor"))
        {
            if (col.collider.name == "Wall1")
            {
                rend.material.color = Color.red;
                bulletLight.color = Color.red;
            }
            else if (col.collider.name == "Wall2")
            {
                rend.material.color = Color.green;
                bulletLight.color = Color.green;
            }
            else if (col.collider.name == "Wall3")
            {
                rend.material.color = Color.blue;
                bulletLight.color = Color.blue;
            }
            else if (col.collider.name == "Wall4")
            {
                rend.material.color = Color.yellow;
                bulletLight.color = Color.yellow;
            }
            else if (col.collider.name == "Ceiling")
            {
                rend.material.color = Color.white;
                bulletLight.color = Color.white;
            }

            Rigidbody colBody = null;
            colBody = col.gameObject.GetComponent<Rigidbody>();
            colBody.AddExplosionForce(500.0f, col.transform.position, 3.0f, 150.0f);

            destructionEmitter.transform.position = bulletBody.transform.position;
            destructionEmitter.Play();

            // Check if object has audio source, if so play it.

            AudioSource objClip = col.gameObject.GetComponent<AudioSource>();
            if (objClip != null)
                objClip.Play();
        }
    }
}
