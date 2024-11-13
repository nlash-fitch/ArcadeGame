using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 4;
    private Rigidbody playerRb;
    public float jumpForce;
    private bool grounded = true;

    public SphereCollider foot1;
    public SphereCollider foot2;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (gameObject.name == "player 1")
            {
                horizontalInput = Input.GetAxis("Horizontal2");
            }
            else
            {
                horizontalInput = Input.GetAxis("Horizontal");
            }

            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

            if (Input.GetKeyDown("space") && grounded == true && gameObject.name == "player 1")
            {
                playerRb.AddForce(Vector3.up * jumpForce);
                grounded = false;
            }
            else if (Input.GetKeyDown("4") && grounded == true && gameObject.name == "player 2")
            {
                playerRb.AddForce(Vector3.up * jumpForce);
                grounded = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        
        if ((collision.gameObject.tag == "Floor") && (contact.thisCollider == foot1 || contact.thisCollider == foot2))
        {
            grounded = true;
        }
        if (collision.gameObject.tag == "hazard")
        {
            
        }
    }

    void OnTriggerEnter(Collider other)
    {

    }

    /*
    private void OnCollisionExit(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);

        if ((collision.gameObject.tag == "Floor") && (contact.thisCollider == feet))
        {
            grounded = false;
        }
    }
    */

}
