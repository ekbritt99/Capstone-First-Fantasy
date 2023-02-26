using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public GameObject gameManager;

    public GameObject shopButton;

    public GameObject sceneTrackerObj;
    // Start is called before the first frame update
    void Start()
    {
        sceneTrackerObj = GameObject.FindGameObjectWithTag("Scene Tracker");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Scene Trigger")
        {
            gameManager.SendMessage("GoToOverWorld");
        }
        if (collision.gameObject.tag == "Scene Trigger 2")
        {
            gameManager.SendMessage("GoToVillage");
        }
        
        if (collision.gameObject.tag == "One")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("One");
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Two")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Two");
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Three")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Three");
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Four")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Four");
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Five")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Five");
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Six")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Six");
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Seven")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Seven");
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Eight")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Eight");
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Nine")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Nine");
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Ten")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Ten");
            gameManager.SendMessage("GoToBattle");
        }
            
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shop Trigger")
        {
            shopButton.SetActive(true);
        }
        if (collision.gameObject.tag == "Scene Trigger")
        {
            gameManager.SendMessage("GoToOverWorld");
        }
        if (collision.gameObject.tag == "Scene Trigger 2")
        {
            gameManager.SendMessage("GoToVillage");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shop Trigger")
        {
            shopButton.SetActive(false);
        }
        
    }
}
