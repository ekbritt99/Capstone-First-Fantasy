using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LimitEnemyLifetime : MonoBehaviour
{
    public float randomLifeTime;
    bool hasCollidedWithPlayer;

    // Start is called before the first frame update
    void Start()
    {
        randomLifeTime = Random.Range(2.0f, 10.0f);
        hasCollidedWithPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().name == "Test World Scene")
        {
            if (transform.position.x != -11.0f)
            {
                randomLifeTime -= Time.deltaTime;
            }

            if (randomLifeTime <= 0.0f)
            {
                if (hasCollidedWithPlayer == false)
                {
                    transform.position = new Vector3(-11.0f, 0.0f, 1.0f);
                    randomLifeTime = Random.Range(5.0f, 10.0f);
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hasCollidedWithPlayer = true;
        }
    }
}
