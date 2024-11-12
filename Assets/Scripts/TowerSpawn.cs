using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    public float spawnY;
    public float spawnX;
    public GameObject[] towers;
    public int timer;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer >= 600)
        {
            int rand = Random.Range(0, towers.Length);
            Vector3 move = new Vector3(0, distance, 0);
            distance = distance + Instantiate(towers[rand], move, new Quaternion(0,0,0,0)).GetComponent<BoxCollider>().bounds.size.y;
            timer = 0;
        }
        
    }
}
