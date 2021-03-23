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
    public GameObject playerGO;

    public GameObject enemyPrefab;
    public Transform enemySpawnPoint;
    public GameObject enemyGO;

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
            playerUnit.numMovesRemaining = playerUnit.maxNumMoves;
        }
    }

    void battleEnemyTurn(){
        enemyGO.GetComponent<Enemy>().enemyPlay();

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
