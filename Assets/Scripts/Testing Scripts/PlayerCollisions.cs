using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (collision.gameObject.tag == "Enemy")
        {
            gameManager.SendMessage("GoToBattle");
        }
        if (collision.gameObject.tag == "Shop Trigger")
        {
            gameManager.SendMessage("GoToShop");
        }
    }
}
