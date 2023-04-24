using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, RAN }

public class BattleSystem : MonoBehaviour, IDataPersistence
{
    public GameObject gameManager;
    public GameObject playerObj;
    public Animator playerAnimator;
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
    [SerializeField] AudioClip bossTheme;
    [SerializeField] AudioClip gameOverTheme;
    AudioSource _audio;
    [SerializeField] private AudioSource attackSound;
    [SerializeField] private AudioSource defendSound;
    [SerializeField] private AudioSource attackSuccessSound;
    [SerializeField] private AudioSource battleWonSound;

    [SerializeField] private PlayerPersistency playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public int currencyReward;
    public TMP_Text currencyRewardDisplay;
    public GameObject wholeCurrencyDisplay;

    public BattleState state;

    string enemyEncountered;
    // Start is called before the first frame update

    void OnEnable()
    {
        playerUnit = GameObject.Find("PlayerPersistency").GetComponent<PlayerPersistency>();
        //check if coming from castle area
        if (GameManager.Instance.prevScene == Scenes.TR_CASTLE_DOOR || GameManager.Instance.prevScene == Scenes.TL_CASTLE_DOOR || GameManager.Instance.prevScene == Scenes.BL_CASTLE_DOOR || GameManager.Instance.prevScene == Scenes.BR_CASTLE_DOOR || GameManager.Instance.prevScene == Scenes.WORLD2) {
            GameObject props = GameObject.FindGameObjectWithTag("props");
            props.SetActive(false);
        }
        GameObject castlebg = GameObject.FindGameObjectWithTag("castle bg");
        castlebg.SetActive(false);
        if (GameManager.Instance.prevScene != Scenes.WORLD2) {
            GameObject world2bg = GameObject.FindGameObjectWithTag("world2bg");
            world2bg.SetActive(false);
        }
            if (GameManager.Instance.prevScene == Scenes.TR_CASTLE_DOOR || GameManager.Instance.prevScene == Scenes.TL_CASTLE_DOOR || GameManager.Instance.prevScene == Scenes.BL_CASTLE_DOOR || GameManager.Instance.prevScene == Scenes.BR_CASTLE_DOOR) {
            castlebg.SetActive(true);
        }
    }
    void Start()
    {
        playerAnimator = playerObj.GetComponentInChildren<Animator>();
        _audio = GetComponent<AudioSource>();
        if(GameManager.Instance.enemyHistory[GameManager.Instance.enemyHistory.Count - 1] == "boss1"
            || GameManager.Instance.enemyHistory[GameManager.Instance.enemyHistory.Count - 1] == "boss2") {
            _audio.clip = bossTheme;
        } else {
            _audio.clip = battleTheme;
        }
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

        playerObj.transform.position = new Vector3(-5.45f, -0.63f, 0f);

        if(sceneTrackerObj == null) {
            enemyGO = Instantiate(enemyBoss2Prefab, new Vector3(4f, -.2f, -4.85f), Quaternion.identity);
            enemyUnit = enemyGO.GetComponent<Unit>();
            currencyReward = Random.Range(3, 5);
        } else {

            int numOfEnemiesEncountered = GameManager.Instance.enemyHistory.Count - 1;
            enemyEncountered = GameManager.Instance.enemyHistory[numOfEnemiesEncountered];
            if (enemyEncountered == "One")
            {
                enemyOnePrefab.SetActive(true);
                enemyGO = enemyOnePrefab;
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(7, 10);
    ;        }
            if (enemyEncountered == "Two")
            {
                enemyTwoPrefab.SetActive(true);
                enemyGO = enemyTwoPrefab;
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(7, 10);
            }
            if (enemyEncountered == "Three")
            {
                enemyThreePrefab.SetActive(true);
                enemyGO = enemyThreePrefab;
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(7, 10);
            }
            if (enemyEncountered == "Four")
            {
                enemyFourPrefab.SetActive(true);
                enemyGO = enemyFourPrefab;
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(3, 5);
            }
            if (enemyEncountered == "Five")
            {
                enemyFivePrefab.SetActive(true);
                enemyGO = enemyFivePrefab;
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(5, 7);
            }
            if (enemyEncountered == "Six")
            {
                enemySixPrefab.SetActive(true);
                enemyGO = enemySixPrefab;
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(7, 10);
            }
            if (enemyEncountered == "Seven")
            {
                enemySevenPrefab.SetActive(true);
                enemyGO = enemySevenPrefab;
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(1, 3);
            }
            if (enemyEncountered == "Eight")
            {
                enemyEightPrefab.SetActive(true);
                enemyGO = enemyEightPrefab;
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(3, 5);
            }
            if (enemyEncountered == "Nine")
            {
                enemyNinePrefab.SetActive(true);
                enemyGO = enemyNinePrefab;
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(3, 5);
            }
            if (enemyEncountered == "Ten")
            {
                enemyTenPrefab.SetActive(true);
                enemyGO = enemyTenPrefab;
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = Random.Range(3, 5);
            }
            if (enemyEncountered == "boss1")
            {
                enemyBossPrefab.SetActive(true);
                enemyGO = enemyBossPrefab;
                enemyUnit = enemyGO.GetComponent<Unit>();
                currencyReward = 50;
            }
            if (enemyEncountered == "boss2")
            {
                enemyBoss2Prefab.SetActive(true);
                enemyGO = enemyBoss2Prefab;
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

        playerAnimator.SetTrigger("Attack");
        attackSound.PlayDelayed(0.4f);
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
        attackSuccessSound.Play();
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
        if (enemyEncountered == "One")
        {
            enemyGO.GetComponent<Animator>().Play("Enemy1Attack");
        }
        if (enemyEncountered == "Two")
        {
            enemyGO.GetComponent<Animator>().Play("Enemy2Attack");
        }
        if (enemyEncountered == "Three")
        {
            enemyGO.GetComponent<Animator>().Play("Enemy3Attack");
        }
        if (enemyEncountered == "Four")
        {
            enemyGO.GetComponent<Animator>().Play("Enemy4Attack");
        }
        if (enemyEncountered == "Five")
        {
            enemyGO.GetComponent<Animator>().Play("Enemy5Attack");
        }
        if (enemyEncountered == "Six")
        {
            enemyGO.GetComponent<Animator>().Play("Enemy6Attack");
        }
        if (enemyEncountered == "Seven")
        {
            enemyGO.GetComponent<Animator>().Play("Enemy7Attack");
        }
        if (enemyEncountered == "Eight")
        {
            enemyGO.GetComponent<Animator>().Play("Enemy8Attack");
        }
        if (enemyEncountered == "Nine")
        {
            enemyGO.GetComponent<Animator>().Play("Enemy9Attack");
        }
        if (enemyEncountered == "Ten")
        {
            enemyGO.GetComponent<Animator>().Play("Enemy10Attack");
        }
        if (enemyEncountered == "boss1")
        {
            enemyGO.GetComponent<Animator>().Play("Boss1Attack");
        }
        if (enemyEncountered == "boss2")
        {
            enemyGO.GetComponent<Animator>().Play("Boss2Attack");
        }
        playerAnimator.SetTrigger("Defend");
        defendSound.Play();
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
            battleWonSound.Play();
            playerUnit.money.addCurrency(currencyReward);
            currencyRewardDisplay.text = currencyReward.ToString();
            wholeCurrencyDisplay.SetActive(true);
            sceneTrackerObj.GetComponent<SceneTracker>().rememberScene();
            yield return new WaitForSeconds(3);
            GameManager.Instance.GoToPreviousScene();
        } 
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated...";
            yield return new WaitForSeconds(1);
            GameOver();
        }
        else
        {
            yield return new WaitForSeconds(1);
            GameManager.Instance.GoToPreviousScene();
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

    public void OnRunButton()
    {
        if(state != BattleState.PLAYERTURN)
            return;

        state = BattleState.ENEMYTURN;

        int runChance = Random.Range(0, 100);
        if(runChance < 65)
        {
            state = BattleState.RAN;
            StartCoroutine(DisplayText("You got away safely!", EndBattle()));
        }
        else
        {
            StartCoroutine(DisplayText("You failed to run away!", EnemyTurn()));
        }
    }

    IEnumerator DisplayText(string text, IEnumerator next = null)
    {
        dialogueText.text = text;
        yield return new WaitForSeconds(2f);
        if(next != null)
            StartCoroutine(next);
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
        if(BattleState.PLAYERTURN == state)
            inventoryOverlay.SetActive(true);
    }

    public void hideInventory()
    {
        inventoryOverlay.SetActive(false);
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
