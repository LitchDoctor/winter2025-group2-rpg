using UnityEngine;
using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;



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

    Player playerUnit;
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
    bool Clicked = false;
    bool Buffed = false;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Player>();

        GameObject humanGO = Instantiate(humanPrefab, humanBattleStation);
        humanUnit = humanGO.GetComponent<Unit>();


        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = enemyUnit.unitName + " has entered the battle.";

        playerUnit.InitializeStats();

        playerHUD.SetHUDPlayer(playerUnit);
        enemyHUD.SetHUD(enemyUnit);
        humanHUD.SetHUD(humanUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        Clicked = false;
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




    IEnumerator PlayerBuff() // change to buff
    {
        dialogueText.text = "The human has been buffed!";
        Buffed = true;

        yield return new WaitForSeconds(2f);
        state = BattleState.HUMANTURN;
        StartCoroutine(HumanTurn());
    }


    public SceneInfo sceneInfo;
    void EndBattle()
    {

        string victoryScene = "stage1";
        string lossScene = "Main Menu";

        if (state == BattleState.WON)
        {
            dialogueText.text = "You have won the battle!";

            sceneInfo.returnedFromBattle = true;

            StartCoroutine(LoadSceneAfterDelay(victoryScene));
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You have lost the battle.";
            StartCoroutine(LoadSceneAfterDelay(lossScene));
        }
    }

    IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(3f); // Wait 3 seconds to show message
        SceneManager.LoadScene(sceneName);
    }

    public void OnHealButton()
    {
        if(!Clicked){
            Clicked = true;
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(PlayerHeal());
        }
        
    }

    IEnumerator PlayerHeal()
    {
        humanUnit.Heal(playerUnit.energy);
        humanHUD.SetHP(humanUnit.currentHP);
        dialogueText.text = "You heal the human for " + playerUnit.energy + " HP!";
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
        bool attackHuman = !IsTaunted && (Random.Range(0, 10) >= 4); // If taunted, always attack player

        if (!RobotAlive)
        {
            attackHuman = true;
        }

        //Unit targetUnit = attackHuman ? humanUnit : playerUnit;
        //BattleHUD targetHUD = attackHuman ? humanHUD : playerHUD;

        dialogueText.text = enemyUnit.unitName + " attacks " + (attackHuman ? "the Human!" : "the Player!");
        yield return new WaitForSeconds(1f);

        int damage = enemyUnit.damage;

        if(attackHuman){ // attack the human
            if(IsBlocked){
                damage /= 2;
                IsBlocked = false;
            }
            isDead = humanUnit.TakeDamage(damage);
            humanHUD.SetHP(humanUnit.currentHP);

        }else { // attack the robot
            damage -= playerUnit.durability;
            isDead = playerUnit.TakeDamage(damage);
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

        if(damage != 0 && Buffed){
            damage += playerUnit.support;
            Buffed = false;
        }

        Debug.Log("human deals "+ damage + "damage");
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
        if(!Clicked){
            Clicked = true;
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(PlayerBuff());
        }
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
        if(!Clicked){
            Clicked = true;
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(PlayerBlock());
        }
        
    }



    public void OnStunButton()
    {
        if(!Clicked){
            Clicked = true;
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(PlayerStun());
        }
    }

    public void OnTauntButton()
    {
        if(!Clicked){
            Clicked = true;
            if (state != BattleState.PLAYERTURN)
                return;

            StartCoroutine(PlayerTaunt());
        }
    }

    IEnumerator PlayerTaunt()
    {
        IsTaunted = true;
        dialogueText.text = "Taunted!";
        yield return new WaitForSeconds(2f);
        StartCoroutine(HumanTurn());
    }

    
}
