using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour, IDataPersistence
{
    
    public GameObject gameManager;

    public float moveSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void moveCommand(Vector3 moveVect)
        {
            //MOVE
            transform.Translate(moveVect);
        }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector3 moveVect = new Vector3(inputX, inputY, 0);
        moveVect *= (moveSpeed * Time.deltaTime);
        moveCommand(moveVect);

        //moved to a separate method to call in testing
        // transform.Translate(moveVect);

    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(GameData data)
    {
        data.playerPosition = this.transform.position;
    }

    
}
