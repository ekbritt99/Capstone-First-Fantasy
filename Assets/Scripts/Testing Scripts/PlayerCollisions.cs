using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public GameObject gameManager;

    public GameObject shopButton;

    public GameObject sceneTrackerObj;

    public GameObject playerObj;
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
            gameManager.SendMessage("GoToVillageFromHouseOrShop");
        }

        if (collision.gameObject.tag == "leave house")
        {
            gameManager.SendMessage("GoToVillageFromHouseOrShop");
        }

        if (collision.gameObject.tag == "One")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("One");
            sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Two")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Two");
            sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Three")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Three");
            sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Four")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Four");
            sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Five")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Five");
            sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Six")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Six");
            sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Seven")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Seven");
            sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Eight")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Eight");
            sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Nine")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Nine");
            sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Ten")
        {
            sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Ten");
            sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            gameManager.SendMessage("GoToBattle");
        } 
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shop Trigger")
        {
            gameManager.SendMessage("GoToShop");
        }
        if (collision.gameObject.tag == "Scene Trigger")
        {
            gameManager.SendMessage("GoToOverWorld");
        }
        if (collision.gameObject.tag == "Scene Trigger 2")
        {
            gameManager.SendMessage("GoToVillage");
        }
        if (collision.gameObject.tag == "house")
        {
            gameManager.SendMessage("GoToHouseScene");
        }
        if (collision.gameObject.tag == "NPC Rat")
        {
            gameManager.SendMessage("DisplayDialogueBox", "Don't forget to stop by the shop to the west of town and buy some gear...");
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
