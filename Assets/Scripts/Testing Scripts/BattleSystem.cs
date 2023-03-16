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

    public InventoryObject playerEquipment;
    public InventoryObject playerInventory;

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

    [SerializeField] private PersistentEntityUnit playerUnit;
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
        playerUnit = GameObject.Find("PlayerPersistency").GetComponent<PersistentEntityUnit>();
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
        playerPrefab.transform.position = new Vector3(-5.45f, -0.57f, 0f);

        if(sceneTrackerObj == null) {
            enemyGO = Instantiate(enemyOnePrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
            enemyUnit = enemyGO.GetComponent<Unit>();
            currencyReward = Random.Range(3, 5);
        } else {

            int numOfEnemiesEncountered = GameManager1.Instance.enemyHistory.Count - 1;
            string enemyEncountered = GameManager1.Instance.enemyHistory[numOfEnemiesEncountered];
            if (enemyEncountered == "One")
            {
                enemyGO = Instantiate(enemyOnePrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(3, 5);
    ;        }
            if (enemyEncountered == "Two")
            {
                enemyGO = Instantiate(enemyTwoPrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(7, 10);
            }
            if (enemyEncountered == "Three")
            {
                enemyGO = Instantiate(enemyThreePrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(5, 7);
            }
            if (enemyEncountered == "Four")
            {
                enemyGO = Instantiate(enemyFourPrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(3, 5);
            }
            if (enemyEncountered == "Five")
            {
                enemyGO = Instantiate(enemyFivePrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(5, 7);
            }
            if (enemyEncountered == "Six")
            {
                enemyGO = Instantiate(enemySixPrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(7, 10);
            }
            if (enemyEncountered == "Seven")
            {
                enemyGO = Instantiate(enemySevenPrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(1, 3);
            }
            if (enemyEncountered == "Eight")
            {
                enemyGO = Instantiate(enemyEightPrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(3, 5);
            }
            if (enemyEncountered == "Nine")
            {
                enemyGO = Instantiate(enemyNinePrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(3, 5);
            }
            if (enemyEncountered == "Ten")
            {
                enemyGO = Instantiate(enemyTenPrefab, new Vector3(5.09f, -1.8f, -4.85f), Quaternion.identity);
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(3, 5);
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
        int helmetBuff = 0;
        int chestBuff = 0;
        int legsBuff = 0;
        int shieldBuff = 0;
        int bootsBuff = 0;
        if (playerEquipment.container.Items[0].item.ID != -1 && playerEquipment.container.Items[0].item.buffs.Length > 0)
        {
            helmetBuff = playerEquipment.container.Items[0].item.buffs[0].value;
        }
        if (playerEquipment.container.Items[1].item.ID != -1 && playerEquipment.container.Items[1].item.buffs.Length > 0)
        {
            chestBuff = playerEquipment.container.Items[1].item.buffs[0].value;
        }
        if (playerEquipment.container.Items[2].item.ID != -1 && playerEquipment.container.Items[2].item.buffs.Length > 0)
        {
            legsBuff = playerEquipment.container.Items[2].item.buffs[0].value;
        }
        if (playerEquipment.container.Items[3].item.ID != -1 && playerEquipment.container.Items[3].item.buffs.Length > 0)
        {
            bootsBuff = playerEquipment.container.Items[3].item.buffs[0].value;
        }
        if (playerEquipment.container.Items[5].item.ID != -1 && playerEquipment.container.Items[4].item.buffs.Length > 0)
        {
            shieldBuff = playerEquipment.container.Items[4].item.buffs[0].value;
        }
        int newEnemyDamage = enemyUnit.damage - (helmetBuff + chestBuff + legsBuff + bootsBuff + shieldBuff);
        bool isDead = playerUnit.TakeDamage(newEnemyDamage);
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
            playerInventory.container.gold.addCurrency(currencyReward);
            currencyRewardDisplay.text = currencyReward.ToString();
            wholeCurrencyDisplay.SetActive(true);
            sceneTrackerObj.GetComponent<SceneTracker>().rememberScene();
            yield return new WaitForSeconds(3);
            GameManager1.Instance.GoToPreviousScene();
        } else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated...";
            yield return new WaitForSeconds(2);
            GameOver();
            //gameManager.SendMessage("GoToOverWorld");
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
    public void onReturnButton() 
    {
        gameManager.SendMessage("GoToOverWorldFromBattle");
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
