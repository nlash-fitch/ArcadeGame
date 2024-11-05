using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody playerRb;
    public float jumpForce;
    private bool grounded = true;

    public SphereCollider foot1;
    public SphereCollider foot2;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right * speed * move);

        if (Input.GetKeyDown("space")&&grounded==true)
        {
            playerRb.AddForce(Vector3.up * jumpForce);
            grounded = false;
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
