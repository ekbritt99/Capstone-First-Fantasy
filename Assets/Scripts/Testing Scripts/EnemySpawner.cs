using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    

    public GameObject typeOneEnemy;
    public GameObject typeTwoEnemy;
    public GameObject typeThreeEnemy;
    public GameObject typeFourEnemy;
    public GameObject typeFiveEnemy;
    public GameObject typeSixEnemy;
    public GameObject typeSevenEnemy;
    public GameObject typeEightEnemy;
    public GameObject typeNineEnemy;
    public GameObject typeTenEnemy;


    public GameObject[] typeOneEnemies;
    public GameObject[] typeTwoEnemies;
    public GameObject[] typeThreeEnemies;
    public GameObject[] typeFourEnemies;
    public GameObject[] typeFiveEnemies;
    public GameObject[] typeSixEnemies;
    public GameObject[] typeSevenEnemies;
    public GameObject[] typeEightEnemies;
    public GameObject[] typeNineEnemies;
    public GameObject[] typeTenEnemies;

    public float DEF_X_POSITION = -11.0f;

    // Start is called before the first frame update
    void Start()
    {
        typeOneEnemies = new GameObject[5];
        typeTwoEnemies = new GameObject[5];
        typeThreeEnemies = new GameObject[5];
        typeFourEnemies = new GameObject[5];
        typeFiveEnemies = new GameObject[5];
        typeSixEnemies = new GameObject[5];
        typeSevenEnemies = new GameObject[5];
        typeEightEnemies = new GameObject[5];
        typeNineEnemies = new GameObject[5];
        typeTenEnemies = new GameObject[5];

        populateEnemyArray(typeOneEnemies, typeOneEnemy);
        populateEnemyArray(typeTwoEnemies, typeTwoEnemy);
        populateEnemyArray(typeThreeEnemies, typeThreeEnemy);
        populateEnemyArray(typeFourEnemies, typeFourEnemy);
        populateEnemyArray(typeFiveEnemies, typeFiveEnemy);
        populateEnemyArray(typeSixEnemies, typeSixEnemy);
        populateEnemyArray(typeSevenEnemies, typeSevenEnemy);
        populateEnemyArray(typeEightEnemies, typeEightEnemy);
        populateEnemyArray(typeNineEnemies, typeNineEnemy);
        populateEnemyArray(typeTenEnemies, typeTenEnemy);

        InvokeRepeating("spawnEnemies", 0.0f, 2.0f);
    }

    public void populateEnemyArray(GameObject[] enemyArray, GameObject enemyType)
    {
        Vector3 location = Vector3.zero;
        location.x = DEF_X_POSITION;
        location.y = 100.0f;
        location.z = 1.0f;

        for (int i = 0; i < 5; i++)
        {
            enemyArray[i] = Instantiate(enemyType, location, Quaternion.identity);
        }
    }

    public void spawnEnemies()
    {
        int randomEnemyType = Random.Range(1, 11);
        
        if (randomEnemyType == 1)
        {
            getNextAvailableEnemy(typeOneEnemies);
        }
        if (randomEnemyType == 2)
        {
            getNextAvailableEnemy(typeTwoEnemies);
        }
        if (randomEnemyType == 3)
        {
            getNextAvailableEnemy(typeThreeEnemies);
        }
        if (randomEnemyType == 4)
        {
            getNextAvailableEnemy(typeFourEnemies);
        }
        if (randomEnemyType == 5)
        {
            getNextAvailableEnemy(typeFiveEnemies);
        }
        if (randomEnemyType == 6)
        {
            getNextAvailableEnemy(typeSixEnemies);
        }
        if (randomEnemyType == 7)
        {
            getNextAvailableEnemy(typeSevenEnemies);
        }
        if (randomEnemyType == 8)
        {
            getNextAvailableEnemy(typeEightEnemies);
        }
        if (randomEnemyType == 9)
        {
            getNextAvailableEnemy(typeNineEnemies);
        }
        if (randomEnemyType == 10)
        {
            getNextAvailableEnemy(typeTenEnemies);
        }
    }

    public void getNextAvailableEnemy(GameObject[] enemyArray)
    {
        for (int i = 0; i < enemyArray.Length; i++)
        {
            if (enemyArray[i].transform.position.x == DEF_X_POSITION)
            {
                float newXPos = Random.Range(-4.5f, 7.14f);
                float newYPos = Random.Range(-4.5f, 2.5f);
                Vector3 newPosition = enemyArray[i].transform.position;
                newPosition.x = newXPos;
                newPosition.y = newYPos;
                enemyArray[i].transform.position = newPosition;
                return;
            }
        }
        spawnEnemies();
    }
    
    public void spawnAllOfEnemyTypeOne()
    {
        for (int i = 0; i < typeOneEnemies.Length; i++)
        {
            if (typeOneEnemies[i].transform.position.x == DEF_X_POSITION)
            {
                float newXPos = Random.Range(-4.5f, 7.14f);
                float newYPos = Random.Range(-4.5f, 2.5f);
                Vector3 newPosition = typeOneEnemies[i].transform.position;
                newPosition.x = newXPos;
                newPosition.y = newYPos;
                typeOneEnemies[i].transform.position = newPosition;
            }
        }
    }

    public void populateAllArrays()
    {
        typeOneEnemies = new GameObject[5];
        typeTwoEnemies = new GameObject[5];
        typeThreeEnemies = new GameObject[5];
        typeFourEnemies = new GameObject[5];
        typeFiveEnemies = new GameObject[5];
        typeSixEnemies = new GameObject[5];
        typeSevenEnemies = new GameObject[5];
        typeEightEnemies = new GameObject[5];
        typeNineEnemies = new GameObject[5];
        typeTenEnemies = new GameObject[5];

        populateEnemyArray(typeOneEnemies, typeOneEnemy);
        populateEnemyArray(typeTwoEnemies, typeTwoEnemy);
        populateEnemyArray(typeThreeEnemies, typeThreeEnemy);
        populateEnemyArray(typeFourEnemies, typeFourEnemy);
        populateEnemyArray(typeFiveEnemies, typeFiveEnemy);
        populateEnemyArray(typeSixEnemies, typeSixEnemy);
        populateEnemyArray(typeSevenEnemies, typeSevenEnemy);
        populateEnemyArray(typeEightEnemies, typeEightEnemy);
        populateEnemyArray(typeNineEnemies, typeNineEnemy);
        populateEnemyArray(typeTenEnemies, typeTenEnemy);

        populateEnemyArray(typeOneEnemies, typeOneEnemy);
        populateEnemyArray(typeTwoEnemies, typeTwoEnemy);
        populateEnemyArray(typeThreeEnemies, typeThreeEnemy);
        populateEnemyArray(typeFourEnemies, typeFourEnemy);
        populateEnemyArray(typeFiveEnemies, typeFiveEnemy);
        populateEnemyArray(typeSixEnemies, typeSixEnemy);
        populateEnemyArray(typeSevenEnemies, typeSevenEnemy);
        populateEnemyArray(typeEightEnemies, typeEightEnemy);
        populateEnemyArray(typeNineEnemies, typeNineEnemy);
        populateEnemyArray(typeTenEnemies, typeTenEnemy);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
