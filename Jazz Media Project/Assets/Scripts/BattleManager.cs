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

    public BattleState gameState;

    public Unit playerUnit;
    //public Unit enemyUnit;

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
        }
        else{
            if (gameState == BattleState.Player_Turn){
                print("IT'S THE PLAYER'S TURN");
                battlePlayerTurn();
            }
            else if (gameState == BattleState.Enemy_Turn){
                print("IT'S THE ENEMY'S TURN");
                battleEnemyTurn();
            }
        }
    }

    void setupBattle(){
        print("To play your turn press SPACE");
        GameObject playerGO = Instantiate(playerPrefab, playerSpawnPoint);
        playerUnit = playerGO.GetComponent<Unit>();

        print(playerUnit.unitName);
        gameState = BattleState.Player_Turn;
    }

    void battlePlayerTurn(){

        if (Input.GetKeyDown("space")){
            gameState = BattleState.Enemy_Turn;
        }
    }

    void battleEnemyTurn(){

        playerUnit.currHP -= 5;
        gameState = BattleState.Player_Turn;
    }

    

}
