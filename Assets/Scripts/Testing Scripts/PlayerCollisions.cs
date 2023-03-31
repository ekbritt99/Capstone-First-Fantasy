using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public GameObject gameManager;

    public GameObject shopButton;

    public GameObject sceneTrackerObj;

    public GameObject playerObj;

    public NPCBubbleManager bubbleManager;
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
            GameManager.Instance.GoToGameScene(Scenes.WORLD);
        }
        if (collision.gameObject.tag == "Scene Trigger 2")
        {
            GameManager.Instance.GoToGameScene(Scenes.VILLAGE);
        }

        if (collision.gameObject.tag == "leave house")
        {
            GameManager.Instance.GoToGameScene(Scenes.VILLAGE);
        }

        if (collision.gameObject.tag == "World 2 Trigger") 
        {
            GameManager.Instance.GoToGameScene(Scenes.WORLD2);
        }

        if (collision.gameObject.tag == "One")
        {
            GameManager.Instance.enemyHistory.Add("One");
            GameManager.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("One");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Two")
        {
            GameManager.Instance.enemyHistory.Add("Two");
            GameManager.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Two");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Three")
        {
            GameManager.Instance.enemyHistory.Add("Three");
            GameManager.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Three");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Four")
        {
            GameManager.Instance.enemyHistory.Add("Four");
            GameManager.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Four");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Five")
        {
            GameManager.Instance.enemyHistory.Add("Five");
            GameManager.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Five");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Six")
        {
            GameManager.Instance.enemyHistory.Add("Six");
            GameManager.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Six");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Seven")
        {
            GameManager.Instance.enemyHistory.Add("Seven");
            GameManager.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Seven");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Eight")
        {
            GameManager.Instance.enemyHistory.Add("Eight");
            GameManager.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Eight");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Nine")
        {
            GameManager.Instance.enemyHistory.Add("Nine");
            GameManager.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Nine");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Ten")
        {
            GameManager.Instance.enemyHistory.Add("Ten");
            GameManager.Instance.GoToGameScene(Scenes.BATTLE);
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberEnemy("Ten");
            // sceneTrackerObj.GetComponent<SceneTracker>().rememberPosition(playerObj.transform.position);
            // gameManager.SendMessage("GoToBattle");
        }

        if (collision.gameObject.tag == "NPCRat2")
        {
            bubbleManager.SendMessage("showShopBubble");
            bubbleManager.SendMessage("startDialogue");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shop Trigger")
        {
            GameManager.Instance.GoToGameScene(Scenes.SHOP);
        }
        if (collision.gameObject.tag == "Scene Trigger")
        {
            GameManager.Instance.GoToGameScene(Scenes.WORLD);
        }
        if (collision.gameObject.tag == "Scene Trigger 2")
        {
            GameManager.Instance.GoToGameScene(Scenes.VILLAGE);
        }
        if (collision.gameObject.tag == "house")
        {
            GameManager.Instance.GoToGameScene(Scenes.HOUSE);
        }
        if (collision.gameObject.tag == "NPC Rat")
        {
            GameManager.Instance.SendMessage("DisplayDialogueBox", "Don't forget to stop by the shop to the west of town and buy some gear...");
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
