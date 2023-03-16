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
            GameManager1.Instance.GoToGameScene(Scenes.WORLD);
        }
        if (collision.gameObject.tag == "Scene Trigger 2")
        {
            GameManager1.Instance.GoToGameScene(Scenes.VILLAGE);
        }

        if (collision.gameObject.tag == "leave house")
        {
            GameManager1.Instance.GoToGameScene(Scenes.VILLAGE);
        }

        if (collision.gameObject.tag == "One")
        {
            GameManager1.Instance.enemyHistory.Add("One");
            GameManager1.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("One");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Two")
        {
            GameManager1.Instance.enemyHistory.Add("Two");
            GameManager1.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Two");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Three")
        {
            GameManager1.Instance.enemyHistory.Add("Three");
            GameManager1.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Three");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Four")
        {
            GameManager1.Instance.enemyHistory.Add("Four");
            GameManager1.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Four");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Five")
        {
            GameManager1.Instance.enemyHistory.Add("Five");
            GameManager1.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Five");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Six")
        {
            GameManager1.Instance.enemyHistory.Add("Six");
            GameManager1.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Six");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Seven")
        {
            GameManager1.Instance.enemyHistory.Add("Seven");
            GameManager1.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Seven");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Eight")
        {
            GameManager1.Instance.enemyHistory.Add("Eight");
            GameManager1.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Eight");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Nine")
        {
            GameManager1.Instance.enemyHistory.Add("Nine");
            GameManager1.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Nine");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Ten")
        {
            GameManager1.Instance.enemyHistory.Add("Ten");
            GameManager1.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Ten");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        } 
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shop Trigger")
        {
            GameManager1.Instance.GoToGameScene(Scenes.SHOP);
        }
        if (collision.gameObject.tag == "Scene Trigger")
        {
            GameManager1.Instance.GoToGameScene(Scenes.WORLD);
        }
        if (collision.gameObject.tag == "Scene Trigger 2")
        {
            GameManager1.Instance.GoToGameScene(Scenes.VILLAGE);
        }
        if (collision.gameObject.tag == "house")
        {
            GameManager1.Instance.GoToGameScene(Scenes.HOUSE);
        }
        if (collision.gameObject.tag == "NPC Rat")
        {
            GameManager1.Instance.SendMessage("DisplayDialogueBox", "Don't forget to stop by the shop to the west of town and buy some gear...");
            // gameManager.SendMessage("DisplayDialogueBox", "Don't forget to stop by the shop to the west of town and buy some gear...");
        }
    }

    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision.gameObject.tag == "Shop Trigger")
    //     {
    //         shopButton.SetActive(false);
    //     }
        
    // }
}
