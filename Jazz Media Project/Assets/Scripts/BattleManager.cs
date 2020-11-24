using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState {
        Start,
        Player_Turn,
        Player_Champ_Turn,
        Enemy_Turn,
        Won,
        Lost
    }

public class BattleManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public Transform playerSpawnPoint;
    private GameObject playerGO;

    public GameObject enemyPrefab;
    public Transform enemySpawnPoint;
    private GameObject enemyGO;

    public BattleState gameState;

    public Unit playerUnit;
    public Unit enemyUnit;

    // Start is called before the first frame update
    void Start()
    {
        gameState = BattleState.Start;
        setupBattle();
        
    }

    void Update(){
        if (playerUnit.currHP <= 0){ // Player is dead
            print(playerUnit.unitName + " is dead");
            gameState = BattleState.Lost;
            enabled = false;
            Destroy(playerGO);
        }
        else if (enemyUnit.currHP <= 0){ // Enemy is Dead
            print(enemyUnit.unitName + " is dead");
            gameState= BattleState.Won;
            enabled = false;
            Destroy(enemyGO);
        }
        else{
            if (gameState == BattleState.Player_Turn){ // Player's Turn
                battlePlayerTurn();
            }
            else if (gameState == BattleState.Enemy_Turn){// Enemy's Turn
                battleEnemyTurn();
            }
        }
    }

    void setupBattle(){
        print("To play your turn press SPACE or RIGHT CLICK");

        playerGO = Instantiate(playerPrefab, playerSpawnPoint);
        playerUnit = playerGO.GetComponent<Unit>();

        enemyGO = Instantiate(enemyPrefab, enemySpawnPoint);
        enemyUnit = enemyGO.GetComponent<Unit>();

        print(playerUnit.unitName);
        gameState = BattleState.Player_Turn;
    }

    void battlePlayerTurn(){
        if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire2")){
            print("Player is taking their turn");
            playerUnit.numMovesRemaining -= 1;            
        }

        if (playerUnit.numMovesRemaining == 0){
            gameState = BattleState.Enemy_Turn;
            print("No moves remaining");
            playerUnit.numMovesRemaining = playerUnit.numMoves;
        }
    }

    // IEnumerator allows the function to be a coroutine 
    // Function is a button listener so it has to be an IEnumerator
    IEnumerator PlayerAttack(){ 
        playerUnit.attack(enemyUnit);
        yield return new WaitForSeconds(1f);
    }

    IEnumerator playerDefend(){
        playerUnit.defend();
        yield return new WaitForSeconds(1f);
    }

    IEnumerator playerTaunt(){
        playerUnit.taunt();
        yield return new WaitForSeconds(1f);
    }

    public void OnAttackButton(){
        if (gameState != BattleState.Player_Turn){
            print (gameState);
            return;
        }
        StartCoroutine(PlayerAttack());
    }

    public void onDefendButton(){
        if (gameState != BattleState.Player_Turn){
            print (gameState);
            return;
        }
        StartCoroutine(playerDefend());
    }

    public void onTauntButton(){
        if (gameState != BattleState.Player_Turn){
            print (gameState);
            return;
        }
        StartCoroutine(playerTaunt());
    }

    

    void battleEnemyTurn(){
        int action = (int) (Random.value * 10) % 3;

        enemyUnit.initTurn();

        while (enemyUnit.numMovesRemaining > 0){
            if (action == 0){ // attack
                enemyUnit.attack(playerUnit);
            } 
            else if (action == 1){ // taunt
                enemyUnit.taunt();
                break;
            }
            else { // defend
                enemyUnit.defend();
            }
        }

        gameState = BattleState.Player_Turn;
        playerUnit.initTurn();
    }

    

}
