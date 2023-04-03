using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour, IDataPersistence
{
    public GameObject gameManager;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject inventoryOverlay;

    public InventoryObject playerEquipment;
    public InventoryObject playerInventory;
    int playerDefense;
    int playerIntellect;
    int playerAgility;
    int playerStrength;

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
    public GameObject enemyBossPrefab;
    public GameObject enemyBoss2Prefab;
    GameObject enemyGO;

    public GameObject sceneTrackerObj;

    public GameOverScreen GameOverScreen;

    [SerializeField] AudioClip battleTheme;
    [SerializeField] AudioClip gameOverTheme;
    AudioSource _audio;

    [SerializeField] private PlayerPersistency playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public int currencyReward;
    public TMP_Text currencyRewardDisplay;
    public GameObject wholeCurrencyDisplay;

    public BattleState state;
    // Start is called before the first frame update

    void OnEnable()
    {
        playerUnit = GameObject.Find("PlayerPersistency").GetComponent<PlayerPersistency>();
    }
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
        // GameObject playerGO = Instantiate(playerPrefab);
        // playerUnit = playerGO.GetComponent<Unit>();
        
        // Loop through player attributes and set each attribute value
        for(int i = 0; i < playerUnit.attributes.Length; i++)
        {
            if(playerUnit.attributes[i].type == Attributes.Defense) {
                playerDefense = playerUnit.attributes[i].value;
            }
            if(playerUnit.attributes[i].type == Attributes.Agility) {
                playerAgility = playerUnit.attributes[i].value;
            }
            if(playerUnit.attributes[i].type == Attributes.Strength) {
                playerStrength = playerUnit.attributes[i].value;
            }
            if(playerUnit.attributes[i].type == Attributes.Intellect) {
                playerIntellect = playerUnit.attributes[i].value;
            }
        }

        playerPrefab.transform.position = new Vector3(-5.45f, -0.63f, 0f);

        if(sceneTrackerObj == null) {
            enemyGO = Instantiate(enemyBoss2Prefab, new Vector3(4f, -.2f, -4.85f), Quaternion.identity);
            enemyUnit = enemyGO.GetComponent<Unit>();
            currencyReward = Random.Range(3, 5);
        } else {

            int numOfEnemiesEncountered = GameManager.Instance.enemyHistory.Count - 1;
            string enemyEncountered = GameManager.Instance.enemyHistory[numOfEnemiesEncountered];
            if (enemyEncountered == "One")
            {
                enemyGO = Instantiate(enemyOnePrefab, new Vector3(5.09f, -1.4f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(3, 5);
    ;        }
            if (enemyEncountered == "Two")
            {
                enemyGO = Instantiate(enemyTwoPrefab, new Vector3(5.09f, -1.4f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(7, 10);
            }
            if (enemyEncountered == "Three")
            {
                enemyGO = Instantiate(enemyThreePrefab, new Vector3(5.09f, -1.4f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(5, 7);
            }
            if (enemyEncountered == "Four")
            {
                enemyGO = Instantiate(enemyFourPrefab, new Vector3(5.09f, -1.4f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(3, 5);
            }
            if (enemyEncountered == "Five")
            {
                enemyGO = Instantiate(enemyFivePrefab, new Vector3(5.09f, -1.4f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(5, 7);
            }
            if (enemyEncountered == "Six")
            {
                enemyGO = Instantiate(enemySixPrefab, new Vector3(5.09f, -1.4f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(7, 10);
            }
            if (enemyEncountered == "Seven")
            {
                enemyGO = Instantiate(enemySevenPrefab, new Vector3(5.09f, -1.4f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(1, 3);
            }
            if (enemyEncountered == "Eight")
            {
                enemyGO = Instantiate(enemyEightPrefab, new Vector3(5.09f, -1.4f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(3, 5);
            }
            if (enemyEncountered == "Nine")
            {
                enemyGO = Instantiate(enemyNinePrefab, new Vector3(5.09f, -1.4f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(3, 5);
            }
            if (enemyEncountered == "Ten")
            {
                enemyGO = Instantiate(enemyTenPrefab, new Vector3(5.09f, -1.4f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(3, 5);
            }
            if (enemyEncountered == "boss1")
            {
                enemyGO = Instantiate(enemyBossPrefab, new Vector3(5.09f, .25f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = 50;
            }
            if (enemyEncountered == "boss2")
            {
                enemyGO = Instantiate(enemyBoss2Prefab, new Vector3(4f, -.2f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = 50;
            }
        }

        Vector3 newEnemyScale = new Vector3(3.0f, 3.0f, 3.0f);
        enemyGO.transform.localScale += newEnemyScale;

        dialogueText.text = "Enemy approaches!";
        playerHUD.setHUD(playerUnit.maxHP, playerUnit.currentHP);
        enemyHUD.setHUD(enemyUnit.maxHP, enemyUnit.currentHP);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    
    IEnumerator PlayerAttack()
    {
        state = BattleState.ENEMYTURN;
        int weaponBuff = 0;
        if (playerEquipment.container.Items[4].item.ID != -1)
        {
            weaponBuff = playerEquipment.container.Items[4].item.buffs[0].value;
        }
        int newPlayerDamage = playerUnit.damage + weaponBuff;
        bool isDead = enemyUnit.TakeDamage(newPlayerDamage);
        enemyHUD.setHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful!";
        yield return new WaitForSeconds(2f);
        if(isDead)
        {
            state = BattleState.WON;
            StartCoroutine(EndBattle());
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
        int newEnemyDamage = enemyUnit.damage - playerDefense;
        bool isDead = false;
        if(newEnemyDamage <= 0)
        {
            dialogueText.text = "You took no damage from the attack!";
        }
        if(newEnemyDamage > 0)
        {
            isDead = playerUnit.TakeDamage(newEnemyDamage);
        }
        playerHUD.setHP(playerUnit.currentHP);
        yield return new WaitForSeconds(1f);
        if(isDead)
        {
            state = BattleState.LOST;
            StartCoroutine(EndBattle());
        } else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    IEnumerator EndBattle()
    {
        if(state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
            playerUnit.money.addCurrency(currencyReward);
            currencyRewardDisplay.text = currencyReward.ToString();
            wholeCurrencyDisplay.SetActive(true);
            sceneTrackerObj.GetComponent<SceneTracker>().rememberScene();
            yield return new WaitForSeconds(3);
            GameManager.Instance.GoToPreviousScene();
        } else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated...";
            yield return new WaitForSeconds(1);
            GameOver();
        }

        DataPersistenceManager.instance.SaveGame();

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

    public void onBattleInventoryBackButton()
    {
        playerHUD.setHP(playerUnit.currentHP);
        if(state != BattleState.PLAYERTURN)
            return;

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    
    public void onBattleInventoryButton()
    {
        if(state != BattleState.PLAYERTURN)
            return;
    }

    public void onReturnButton() 
    {
        playerUnit.currentHP = 1;
        GameManager.Instance.GoToGameScene(Scenes.VILLAGE);
    }
    public static int returnZero()
    {
        int number = 0;
        return number;
    }

    public void hideEnemy()
    {
        enemyGO.SetActive(false);
    }

    public void showEnemy()
    {
        enemyGO.SetActive(true);    
    }

    public void showInventory()
    {
        inventoryOverlay.GetComponent<Canvas>().enabled = true;
    }

    public void hideInventory()
    {
        inventoryOverlay.GetComponent<Canvas>().enabled = false;
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

    public void LoadData(GameData data)
    {
        // Debug.Log(playerUnit.currentHP);
    }

    public void SaveData(GameData data)
    {
        // data.playerHealth = playerUnit.currentHP;
        // Debug.Log("Save data called with " + playerUnit.currentHP);

    }
}
