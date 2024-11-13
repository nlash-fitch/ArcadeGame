using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private GameManager gameManager;

    public float cooldown = 1.0f;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Arrow"))
        {
            Destroy(gameObject);
        }

        gameManager.UpdateLives();

        timer += Time.deltaTime;
        Debug.Log(other);
        if (timer >= cooldown)
        {
            
            timer = 0;
        }
    }
}
