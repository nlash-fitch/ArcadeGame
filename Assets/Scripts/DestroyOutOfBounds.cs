using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float rightBound = 6;
    private float leftBound = -18;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > rightBound)
        {
            //Destroy(gameObject);
        }
        else if (transform.position.x < leftBound)
        {
            //Destroy(gameObject);
        }
    }
}
