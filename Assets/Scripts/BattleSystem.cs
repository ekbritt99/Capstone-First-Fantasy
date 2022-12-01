using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab);
        playerUnit = playerGO.GetComponent<Unit>();
        
        GameObject enemyGO = Instantiate(enemyPrefab);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "Enemy approaches!";
        playerHUD.setHUD(playerUnit);
        enemyHUD.setHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    
    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyHUD.setHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful!";
        yield return new WaitForSeconds(2f);
        if(isDead)
        {
            state = BattleState.WON;
            EndBattle();
        } else
        {
            state = BattleState.ENEMYTURN;
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
        } else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated.";
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an Action:";
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);
        playerHUD.setHP(playerUnit.currentHP);
        dialogueText.text = "You heal some HP!";
        yield return new WaitForSeconds(1f);
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
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
}
