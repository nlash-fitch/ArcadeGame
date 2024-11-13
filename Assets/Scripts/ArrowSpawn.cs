using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public GameObject arrowPrefab;
    private GameManager gameManager;

    public float spawnRate = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartCoroutine("SpawnArrow");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnArrow()
    {
        while (gameManager.isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(arrowPrefab, transform.position, arrowPrefab.transform.rotation);
        }
    }
}
