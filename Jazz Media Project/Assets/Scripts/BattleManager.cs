using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject playerHand;

    public BattleState gameState;

    public Unit playerUnit;
    public Unit enemyUnit;

    public Player player;

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

        playerPrefab.GetComponent<Player>().battleManager = this;
        playerPrefab.GetComponent<Player>().hand = playerHand;
        playerGO = Instantiate(playerPrefab, playerSpawnPoint);
        playerUnit = playerGO.GetComponent<Unit>();
        player = playerGO.GetComponent<Player>();

        enemyGO = Instantiate(enemyPrefab, enemySpawnPoint);
        enemyUnit = enemyGO.GetComponent<Unit>();

        gameState = BattleState.Player_Turn;
    }

    void battlePlayerTurn(){

        if (playerUnit.numMovesRemaining <= 0){
            gameState = BattleState.Enemy_Turn;
            print("No moves remaining");
            playerUnit.numMovesRemaining = playerUnit.maxNumMoves;
        }
    }

    void battleEnemyTurn(){
        int action = (int) (Random.value * 10) % 3;


        enemyUnit.initTurn();

        while (enemyUnit.numMovesRemaining > 0){
            if (action == 0){ // attack
                enemyUnit.attack(playerUnit, enemyUnit.attackPts);
            } 
            else if (action == 1){ // taunt
                enemyUnit.taunt();
                break;
            }
            else { // defend
                enemyUnit.defend();
            }
        }
        playerUnit.initTurn();

        gameState = BattleState.Player_Turn;
        
    }

    public void DealCardBtnListen()
    {
        if (gameState == BattleState.Player_Turn)
        {
            player.DealCard();
        }
    }
}
