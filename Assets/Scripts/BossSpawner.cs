using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSpawner : MonoBehaviour
{

    public GameObject enemyBoss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //this doesnt work
        if (SceneManager.GetActiveScene().name == "World Scene 2")
        {
            enemyBoss.SetActive(false);
        }
    }
}
