using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMoveForward : MonoBehaviour
{
    private float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move arrow forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
