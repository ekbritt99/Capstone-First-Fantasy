using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string villageScene = "Test Village Scene";
    public string overworldScene = "Test World Scene";

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoToVillage()
    {
        SceneManager.LoadScene(villageScene);
    }

    void GoToOverWorld()
    {
        SceneManager.LoadScene(overworldScene);
    }
}
