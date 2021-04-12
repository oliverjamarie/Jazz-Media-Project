﻿using System.Collections;
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

    public GameObject playerUI, champUI;

    public GameObject playerPrefab;
    public GameObject playerGO;
    public GameObject playerHand;
    public Transform playerSpawnPoint;
    public Unit playerUnit;


    public GameObject enemyPrefab;
    public Transform enemySpawnPoint;
    public GameObject enemyGO;
    public Unit enemyUnit;

    public GameObject champGO;
    public Transform champSpawnPoint;
    public Unit champUnit;
    public bool champInPlay;

    public BattleState gameState;
    public LevelLoader loader;


    // Start is called before the first frame update
    void Start()
    {
        gameState = BattleState.Start;
        setupBattle();
        playerUI = GameObject.FindGameObjectWithTag("PlayerUI");
        champUI = GameObject.FindGameObjectWithTag("ChampUI");
        champUI.SetActive(false);
    }

    void Update()
    {
        //if (champInPlay == false && GameObject.FindGameObjectWithTag("Champion") != null)
        //{
        //    print("heck");
        //    Destroy(champGO);
        //}

        

        if (playerUnit.currHP <= 0)
        { // Player is dead
            print(playerUnit.unitName + " is dead");
            gameState = BattleState.Lost;
            enabled = false;
            Destroy(playerGO);
        }
        else if (enemyUnit.currHP <= 0)
        { // Enemy is Dead
            print(enemyUnit.unitName + " is dead");
            gameState = BattleState.Won;
            enabled = false;
            Destroy(enemyGO);
        }
        else if (champInPlay)
        {
            if (champUnit.currHP <= 0)
            {
                print("Champion is dead");
                Destroy(champGO);
                print(champGO.name);
                champInPlay = false;
                champUI.SetActive(false);
            }
            else if (champUnit.currStamina <= 0)
            {
                print("Champion ran out of stamina");
                Destroy(GameObject.FindGameObjectWithTag("Champion"));
                champInPlay = false;
                champUI.SetActive(false);
            }
            
        }

        if (gameState == BattleState.Player_Turn)
        { // Player's Turn
            battlePlayerTurn();
        }
        else if (gameState == BattleState.Enemy_Turn)
        {// Enemy's Turn
            battleEnemyTurn();
        }
        else if (champInPlay && gameState == BattleState.Player_Champ_Turn)
        {
            battleChampTurn();
        }
        else if (!champInPlay && gameState == BattleState.Player_Champ_Turn)
        {
            print("howdy");
            gameState = BattleState.Player_Turn;
            battlePlayerTurn();
        }
        else if (gameState == BattleState.Lost)
        {
            loader.loadGameOverScene();
        }
        else if (gameState == BattleState.Won)
        {
            loader.loadNextScene();
        }

    }

    void setupBattle()
    {
        playerPrefab.GetComponent<Player>().handTransform = playerHand;
        playerGO = Instantiate(playerPrefab, playerSpawnPoint);
        playerUnit = playerGO.GetComponent<Unit>();

        enemyGO = Instantiate(enemyPrefab, enemySpawnPoint);
        enemyUnit = enemyGO.GetComponent<Unit>();

        gameState = BattleState.Player_Turn;

        champInPlay = false;

        if (playerHand == null)
        {
            playerHand = GameObject.FindGameObjectWithTag("Hand");
        }
    }

    public void setupChamp(GameObject champPrefab)
    {
        champGO = Instantiate(champPrefab, champSpawnPoint.transform);
        champUnit = champGO.GetComponent<Unit>();
        //champUI.SetActive(true);
        champUI.GetComponent<UnitUI>().enabled = true;
        champGO.tag = "Champion";
        champInPlay = true;
    }

    void battlePlayerTurn()
    {
        champUI.SetActive(false);
        playerUI.SetActive(true);
        Transform alt = GameObject.FindGameObjectWithTag("AlternateHand").transform;
        GameObject[] playerCards = GameObject.FindGameObjectsWithTag("PlayerCard");

        if (champInPlay)
        {
            GameObject[] champCards = GameObject.FindGameObjectsWithTag("ChampCard");

            foreach (GameObject card in playerCards)
            {
                if (card.transform.IsChildOf(alt))
                {
                    card.transform.SetParent(playerHand.transform);
                }
            }

            foreach (GameObject card in champCards)
            {
                if (card.transform.IsChildOf(playerHand.transform))
                {
                    card.transform.SetParent(alt);
                }
            }
        }
        else
        {
            foreach (GameObject card in playerCards)
            {
                if (card.transform.IsChildOf(alt))
                {
                    card.transform.SetParent(playerHand.transform);
                }
            }
        }
        

        if (playerUnit.numMovesRemaining <= 0)
        {
            gameState = BattleState.Enemy_Turn;
            playerUnit.numMovesRemaining = playerUnit.maxNumMoves;
        }
    }

    void battleEnemyTurn()
    {
        enemyGO.GetComponent<Enemy>().enemyPlay();

        if (champInPlay == false)
        {
            playerUnit.initTurn();

            gameState = BattleState.Player_Turn;
        }
        else
        {
            print("Champ turn");
            champUnit.initTurn();
            gameState = BattleState.Player_Champ_Turn;
        }

    }

    void battleChampTurn()
    {
        champUI.SetActive(true);
        playerUI.SetActive(false);
        Transform alt = GameObject.FindGameObjectWithTag("AlternateHand").transform;
        GameObject[] playerCards = GameObject.FindGameObjectsWithTag("PlayerCard");
        GameObject[] champCards = GameObject.FindGameObjectsWithTag("ChampCard");

        foreach (GameObject card in playerCards)
        {
            if (card.transform.IsChildOf(playerHand.transform))
            {
                card.transform.SetParent(alt);
            }
        }

        foreach (GameObject card in champCards)
        {
            if (card.transform.IsChildOf(alt))
            {
                card.transform.SetParent(playerHand.transform);
            }
        }

        if (champUnit.numMovesRemaining <= 0)
        {
            playerUnit.initTurn();
            champUnit.endTurn();
            gameState = BattleState.Player_Turn;
        }
    }

    public void DealCardBtnListen()
    {
        StartCoroutine(dealCard());
    }

    IEnumerator dealCard()
    {
        if (gameState == BattleState.Player_Turn)
        {
            playerGO.GetComponent<Player>().DealCard();
        }

        yield return null;
    }

    public Player getPlayer()
    {
        if (gameState == BattleState.Player_Turn)
        {
            return playerUnit.player;
        }

        if (gameState == BattleState.Player_Champ_Turn)
        {
            print(champUnit.player.getCurrHandSize());
            return champUnit.player;
        }


        return null;
    }

    
}
