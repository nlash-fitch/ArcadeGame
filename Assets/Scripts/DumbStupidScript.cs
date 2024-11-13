using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbStupidScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.GetComponent<BoxCollider>().bounds.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
