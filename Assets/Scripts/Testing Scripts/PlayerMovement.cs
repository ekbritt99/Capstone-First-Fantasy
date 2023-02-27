using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour, IDataPersistence
{
    
    public GameObject gameManager;
    private Animator animator;

    public float moveSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    void moveCommand(Vector3 moveVect)
        {
            //MOVE
            transform.Translate(moveVect);
            animator.SetBool("Walk", true);
        }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = this.gameObject.transform.localScale;
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector3 moveVect = new Vector3(inputX, inputY, 0);
        moveVect *= (moveSpeed * Time.deltaTime);

        // If moving right, make sprite face right
        if(moveVect.x > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        } else if(moveVect.x < 0){
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        
        if(moveVect != Vector3.zero)
            moveCommand(moveVect);
        else
            animator.SetBool("Walk", false);

        //moved to a separate method to call in testing
        // transform.Translate(moveVect);

    }

    private void FixedUpdate()
    {
        
    }

    public void LoadData(GameData data)
    {
        // this.transform.position = data.playerPosition;
    }

    public void SaveData(GameData data)
    {
        // data.playerPosition = this.transform.position;
    }

    
}
