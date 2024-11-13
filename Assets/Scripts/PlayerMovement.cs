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

    public float score;
    public int scorePenalty;
    public int displayScore;

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
        score = transform.position.y + 3;
        //Debug.Log(score);
        if (score-(20*scorePenalty)>= displayScore)
        {
            displayScore=(int)Mathf.Floor(score) - (20 * scorePenalty);
        }
    }
    public int getScore()
    {
        return displayScore;
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
            scorePenalty++;
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
