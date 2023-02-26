using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public InventoryObject playerEquipment;

    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject enemyThreePrefab;
    public GameObject enemyFourPrefab;
    public GameObject enemyFivePrefab;
    public GameObject enemySixPrefab;
    public GameObject enemySevenPrefab;
    public GameObject enemyEightPrefab;
    public GameObject enemyNinePrefab;
    public GameObject enemyTenPrefab;
    GameObject enemyGO;

    public GameObject sceneTrackerObj;

    public GameOverScreen GameOverScreen;

    [SerializeField] AudioClip battleTheme;
    [SerializeField] AudioClip gameOverTheme;
    AudioSource _audio;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.clip = battleTheme;
        PlayMusic();
        state = BattleState.START;
        sceneTrackerObj = GameObject.FindGameObjectWithTag("Scene Tracker");
        StartCoroutine(SetupBattle());

        
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab);
        playerUnit = playerGO.GetComponent<Unit>();

        int numOfEnemiesEncountered = sceneTrackerObj.GetComponent<SceneTracker>().enemyHistory.Count - 1;
        if (sceneTrackerObj.GetComponent<SceneTracker>().enemyHistory[numOfEnemiesEncountered] == "One")
        {
            enemyGO = Instantiate(enemyOnePrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
            enemyUnit = enemyGO.GetComponent<Unit>();
        }
        if (sceneTrackerObj.GetComponent<SceneTracker>().enemyHistory[numOfEnemiesEncountered] == "Two")
        {
            enemyGO = Instantiate(enemyTwoPrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
            enemyUnit = enemyGO.GetComponent<Unit>();
        }
        if (sceneTrackerObj.GetComponent<SceneTracker>().enemyHistory[numOfEnemiesEncountered] == "Three")
        {
            enemyGO = Instantiate(enemyThreePrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
            enemyUnit = enemyGO.GetComponent<Unit>();
        }
        if (sceneTrackerObj.GetComponent<SceneTracker>().enemyHistory[numOfEnemiesEncountered] == "Four")
        {
            enemyGO = Instantiate(enemyFourPrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
            enemyUnit = enemyGO.GetComponent<Unit>();
        }
        if (sceneTrackerObj.GetComponent<SceneTracker>().enemyHistory[numOfEnemiesEncountered] == "Five")
        {
            enemyGO = Instantiate(enemyFivePrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
            enemyUnit = enemyGO.GetComponent<Unit>();
        }
        if (sceneTrackerObj.GetComponent<SceneTracker>().enemyHistory[numOfEnemiesEncountered] == "Six")
        {
            enemyGO = Instantiate(enemySixPrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
            enemyUnit = enemyGO.GetComponent<Unit>();
        }
        if (sceneTrackerObj.GetComponent<SceneTracker>().enemyHistory[numOfEnemiesEncountered] == "Seven")
        {
            enemyGO = Instantiate(enemySevenPrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
            enemyUnit = enemyGO.GetComponent<Unit>();
        }
        if (sceneTrackerObj.GetComponent<SceneTracker>().enemyHistory[numOfEnemiesEncountered] == "Eight")
        {
            enemyGO = Instantiate(enemyEightPrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
            enemyUnit = enemyGO.GetComponent<Unit>();
        }
        if (sceneTrackerObj.GetComponent<SceneTracker>().enemyHistory[numOfEnemiesEncountered] == "Nine")
        {
            enemyGO = Instantiate(enemyNinePrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
            enemyUnit = enemyGO.GetComponent<Unit>();
        }
        if (sceneTrackerObj.GetComponent<SceneTracker>().enemyHistory[numOfEnemiesEncountered] == "Ten")
        {
            enemyGO = Instantiate(enemyTenPrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
            enemyUnit = enemyGO.GetComponent<Unit>();
        }

        Vector3 newEnemyScale = new Vector3(3.0f, 3.0f, 3.0f);
        enemyGO.transform.localScale += newEnemyScale;

        dialogueText.text = "Enemy approaches!";
        playerHUD.setHUD(playerUnit);
        enemyHUD.setHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    
    IEnumerator PlayerAttack()
    {
        state = BattleState.ENEMYTURN;
        int newPlayerDamage = playerUnit.damage + playerEquipment.database.GetItem[4].data.buffs[0].value;
        bool isDead = enemyUnit.TakeDamage(newPlayerDamage);
        enemyHUD.setHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful!";
        yield return new WaitForSeconds(2f);
        if(isDead)
        {
            state = BattleState.WON;
            EndBattle();
        } else
        {
            //state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = "Enemy attacks!";
        yield return new WaitForSeconds(1f);
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerHUD.setHP(playerUnit.currentHP);
        yield return new WaitForSeconds(1f);
        if(isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        } else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
            gameManager.SendMessage("GoToOverWorld");
        } else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated...";
            GameOver();
            //gameManager.SendMessage("GoToOverWorld");
        }

    }
    void GameOver() 
    {
        StopMusic();
        _audio.clip = gameOverTheme;
        PlayMusic();
        GameOverScreen.Setup();
    }
    void PlayerTurn()
    {
        dialogueText.text = "Choose an Action:";
    }

    IEnumerator PlayerHeal()
    {
        state = BattleState.ENEMYTURN;
        if(playerUnit.currentHP == playerUnit.maxHP)
        {
            dialogueText.text = "You are already at max health!";
            yield return new WaitForSeconds(1f);
            StartCoroutine(EnemyTurn());
        }
        else
        {
            playerUnit.Heal(5);
            playerHUD.setHP(playerUnit.currentHP);
            dialogueText.text = "You heal some HP!";
            yield return new WaitForSeconds(1f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }  
    }
    public void onAttackButton()
    {
        if(state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void onHealButton()
    {
        if(state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }
    public void onReturnButton() 
    {
        gameManager.SendMessage("GoToOverWorld");
    }
    public static int returnZero()
    {
        int number = 0;
        return number;
    }

    //MUSIC INTERFACE
    public void PlayPauseMusic()
    {
        // Check if the music is currently playing.
        if(_audio.isPlaying)
            _audio.Pause(); // Pause if it is
        else
            _audio.Play(); // Play if it isn't
    }
 
    public void PlayStop()
    {
        if(_audio.isPlaying)
            _audio.Stop();
        else
            _audio.Play();
    }
 
    public void PlayMusic()
    {  
        _audio.Play();
    }
 
    public void StopMusic()
    {
        _audio.Stop();
    }
 
    public void PauseMusic()
    {
        _audio.Pause();
    }
}
