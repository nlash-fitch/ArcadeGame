using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    public GameObject arrowPrefab;
    private GameManager gameManager;

    public float spawnRate = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
            Debug.Log(transform.position);
            Instantiate(arrowPrefab, transform.position, transform.rotation);
        }
    }
}
