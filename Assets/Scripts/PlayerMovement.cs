using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody playerRb;
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
    }
}
