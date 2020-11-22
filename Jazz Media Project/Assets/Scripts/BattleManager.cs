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
        if (playerUnit.currHP <= 0){
            print(playerUnit.unitName + " is dead");
            gameState = BattleState.Lost;
            enabled = false;
            Destroy(playerGO);
        }
        else{
            if (gameState == BattleState.Player_Turn){
                battlePlayerTurn();
            }
            else if (gameState == BattleState.Enemy_Turn){
                battleEnemyTurn();
            }
        }
    }

    void setupBattle(){
        print("To play your turn press SPACE");

        playerGO = Instantiate(playerPrefab, playerSpawnPoint);
        playerUnit = playerGO.GetComponent<Unit>();

        enemyGO = Instantiate(enemyPrefab, enemySpawnPoint);
        enemyUnit = enemyGO.GetComponent<Unit>();

        print(playerUnit.unitName);
        gameState = BattleState.Player_Turn;
    }

    void battlePlayerTurn(){
        if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire1")){
            print("Player is taking their turn");
            playerUnit.numMovesRemaining -= 1;            
        }

        if (playerUnit.numMovesRemaining == 0){
            gameState = BattleState.Enemy_Turn;
            
            playerUnit.numMovesRemaining = playerUnit.numMoves;
        }
    }

    void battleEnemyTurn(){
        print("Enemy is taking their turn");
        int action = (int) (Random.value * 10) % 3;

        for(int i = 0; i < enemyUnit.numMovesRemaining; i ++){
            if (action == 0){ // attack
                print ("Enemy is attacking");
                playerUnit.currHP -= 2;
            } 
            else if (action == 1){ // taunt
                print("Enemy is tauting");
                enemyUnit.numMovesRemaining += 1;
                break;
            }
            else { // defend
                print("Enemy is defending");
            }
        }

        enemyUnit.numMovesRemaining = enemyUnit.numMoves;

        gameState = BattleState.Player_Turn;
    }

    

}
