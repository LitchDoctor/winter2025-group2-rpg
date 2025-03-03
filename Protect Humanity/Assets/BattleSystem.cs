using UnityEngine;
using System.Collections;
using TMPro;
using System.Collections.Generic;



public enum BattleState { START, PLAYERTURN, HUMANTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject humanPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;
    public Transform humanBattleStation;

    Unit playerUnit;
    Unit enemyUnit;
    Unit humanUnit;

    public TMP_Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    public BattleHUD humanHUD;

    public BattleState state;

    bool IsBlocked = false;
    bool IsTaunted = false;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject humanGO = Instantiate(humanPrefab, humanBattleStation);
        humanUnit = humanGO.GetComponent<Unit>();


        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = enemyUnit.unitName + " has entered the battle.";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);
        humanHUD.SetHUD(humanUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
    }

  

    IEnumerator PlayerAttack()
    {

        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        if (isDead)
        {
            state = BattleState.WON;
            enemyHUD.SetHP(enemyUnit.currentHP = 0);
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            enemyHUD.SetHP(enemyUnit.currentHP);
            dialogueText.text = "You deal " + playerUnit.damage + " damage...";

            yield return new WaitForSeconds(2f);
            StartCoroutine(EnemyTurn());
        }

    }

    void EndBattle()
    {

        if (state == BattleState.WON)
        {
            dialogueText.text = "You have won the battle!";
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You have lost the battle.";
        }

    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);
        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "You healed for 5 HP!";
        yield return new WaitForSeconds(2f);
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        bool isDead = false;
        bool attackHuman = false;

        if (!IsTaunted)
        {
            dialogueText.text = enemyUnit.unitName + " is deciding who to attack...";
            yield return new WaitForSeconds(1f);

            // Randomly choose target: 0 = Player (Robot), 1 = Human (NPC)
            attackHuman = Random.Range(0, 2) == 1;

            // Determine target unit and HUD
            Unit targetUnit = attackHuman ? humanUnit : playerUnit;
            BattleHUD targetHUD = attackHuman ? humanHUD : playerHUD;

            dialogueText.text = enemyUnit.unitName + " attacks " + (attackHuman ? "the Human!" : "the Player!");
            yield return new WaitForSeconds(1f);

            int damage = enemyUnit.damage;

            if (IsBlocked && attackHuman) // Block only affects the human (NPC)
            {
                damage /= 2; // Reduce damage to the human if the player blocks
                IsBlocked = false;
            }

            isDead = targetUnit.TakeDamage(damage);
            targetHUD.SetHP(targetUnit.currentHP);
        }
        else
        {
            // taunt is active, attack robot
            dialogueText.text = "The enemy is taunted so it attacks the robot";
            isDead = playerUnit.TakeDamage(enemyUnit.damage);
            playerHUD.SetHP(playerUnit.currentHP);
            IsTaunted = false;
        }
        

        

        

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            if (attackHuman)
            {
                dialogueText.text = "The Human has fallen!";
                yield return new WaitForSeconds(2f);
                state = BattleState.LOST;
                EndBattle();
                // The game is over because the Human dies
            }
            else
            {
                state = BattleState.LOST; // The robot died, needs further implementation
                EndBattle();
            }
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerStun()
    {
        int rand = Random.Range(0, 10);

        // if the number is 0 - 5
        if(rand <= 5)
        {
            // stun works
            dialogueText.text = "The enemy is stunned!";
            yield return new WaitForSeconds(2f);
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
        else
        {
            // stun fails
            dialogueText.text = "Oh no! The stun failed!";
            yield return new WaitForSeconds(2f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerBlock()
    {
        IsBlocked = true;
        dialogueText.text = "Blocked";
        yield return new WaitForSeconds(2f);
        StartCoroutine(EnemyTurn());
    }

    public void OnBlockButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerBlock());
    }



    public void OnStunButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerStun());
    }

    public void OnTauntButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerTaunt());
    }

    IEnumerator PlayerTaunt()
    {
        IsTaunted = true;
        dialogueText.text = "Taunted!";
        yield return new WaitForSeconds(2f);
        StartCoroutine(EnemyTurn());
    }

    
}
