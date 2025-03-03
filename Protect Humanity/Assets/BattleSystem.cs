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

    public GameObject playerGO;

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
    bool IsStunned = false;
    bool RobotAlive = true;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        playerGO = Instantiate(playerPrefab, playerBattleStation);
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
        if (!RobotAlive)
        {
            StartCoroutine(SkipToHumanTurn());
        }
        else
        {
            dialogueText.text = "Choose an action:";
        }
    }

    IEnumerator SkipToHumanTurn()
    {
        dialogueText.text = "The robot is down, but the human can still fight!";
        yield return new WaitForSeconds(2f);
        state = BattleState.HUMANTURN;
        StartCoroutine(HumanTurn());
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
            
            enemyHUD.SetHP(enemyUnit.currentHP);
            dialogueText.text = "You deal " + playerUnit.damage + " damage...";

            yield return new WaitForSeconds(2f);
            state = BattleState.HUMANTURN;
            StartCoroutine(HumanTurn());
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
            GameBehaviour.Instance.SetNextEncounter(stage1);
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
        state = BattleState.HUMANTURN;
        StartCoroutine(HumanTurn());
    }

    IEnumerator EnemyTurn()
    {
        if (IsStunned)
        {
            dialogueText.text = enemyUnit.unitName + " is stunned and skips its turn!";
            yield return new WaitForSeconds(2f);
            IsStunned = false;
            state = BattleState.PLAYERTURN;
            PlayerTurn();
            yield break;
        }

        bool isDead = false;
        bool attackHuman = !IsTaunted && Random.Range(0, 2) == 1; // If taunted, always attack player

        if (!RobotAlive)
        {
            attackHuman = true;
        }

        Unit targetUnit = attackHuman ? humanUnit : playerUnit;
        BattleHUD targetHUD = attackHuman ? humanHUD : playerHUD;

        dialogueText.text = enemyUnit.unitName + " attacks " + (attackHuman ? "the Human!" : "the Player!");
        yield return new WaitForSeconds(1f);

        int damage = enemyUnit.damage;

        if (attackHuman && IsBlocked)
        {
            damage /= 2;
            IsBlocked = false;
        }

        isDead = targetUnit.TakeDamage(damage);
        targetHUD.SetHP(targetUnit.currentHP);
        IsTaunted = false; // Taunt ends after enemy attacks

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            if (attackHuman)
            {
                dialogueText.text = "The Human has fallen!";
                yield return new WaitForSeconds(2f);
                state = BattleState.LOST;
                EndBattle();
                yield break;
            }
            else
            {
                RobotAlive = false;
                playerHUD.gameObject.SetActive(false); // Hide player UI
                playerGO.SetActive(false); //  hide robot model
                dialogueText.text = "The robot has fallen!";
                yield return new WaitForSeconds(2f);
                state = BattleState.HUMANTURN;
                StartCoroutine(HumanTurn());
                yield break;
            }
        }



        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }


    IEnumerator HumanTurn()
    {
        if (!RobotAlive)
        {
            dialogueText.text = "The Human is fighting alone!";
            yield return new WaitForSeconds(1f);
        }


        int rand = Random.Range(0, 100);
        int damage = humanUnit.damage;

        if (rand < 25)
        {
            dialogueText.text = "The Human briefly falls asleep";
            damage = 0;
        }
        else if (rand < 50)
        {
            dialogueText.text = "The Human swings and misses";
            damage = 0;
        }
        else if (rand < 80)
        {
            dialogueText.text = "The Human does some damage";
        }
        else
        {
            dialogueText.text = "The Human scores a direct hit!";
            damage *= 2;
        }

        yield return new WaitForSeconds(2f);

        bool isDead = enemyUnit.TakeDamage(damage);
        enemyHUD.SetHP(enemyUnit.currentHP);

        if (isDead)
        {
            state = BattleState.WON;
            enemyHUD.SetHP(enemyUnit.currentHP = 0);
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
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

        // if the number is 0 - 5 (60% chance)
        if(rand <= 5)
        {
            // stun works
            dialogueText.text = "The enemy is stunned!";
            IsStunned = true;
            yield return new WaitForSeconds(2f);
            state = BattleState.HUMANTURN;
            StartCoroutine(HumanTurn());
        }
        else
        {
            // stun fails
            dialogueText.text = "Oh no! The stun failed!";
            yield return new WaitForSeconds(2f);
            state = BattleState.HUMANTURN;
            StartCoroutine(HumanTurn());
        }
    }

    IEnumerator PlayerBlock()
    {
        IsBlocked = true;
        dialogueText.text = "Blocked";
        yield return new WaitForSeconds(2f);
        StartCoroutine(HumanTurn());
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
        StartCoroutine(HumanTurn());
    }

    
}
