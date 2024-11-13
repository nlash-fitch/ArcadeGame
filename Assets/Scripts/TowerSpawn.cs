using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    public float spawnY;
    public float spawnX;
    public GameObject[] towers;
    public int timer;
    public float distance = 20.02971f;
    public float[,] towerAskewXY = { { -1.13f, 6.56f },{ 0.39f, 8.62f } };
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
            Vector3 move = new Vector3(towerAskewXY[0,rand], distance + towerAskewXY[1,rand], 0);
            distance = distance + Instantiate(towers[rand], move, new Quaternion(0,0,0,0)).GetComponent<BoxCollider>().bounds.size.y;
            timer = 0;
        }
        
    }
}
