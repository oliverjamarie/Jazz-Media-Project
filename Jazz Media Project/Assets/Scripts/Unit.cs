using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Unit : MonoBehaviour
{
    public string unitName;

    public int maxHP;
    public int currHP;

    public int maxStamina;
    public int currStamina;

    public int maxNumMoves;
    public int numMovesRemaining;

    public int defense;
    public int defensePts;
    public int attackPts;

    //public bool isTurn;
    public bool usesStamina;
    public Player player;

    public enum unitTypeEnum{
        Player,
        Champion,
        Enemy
    }

    public unitTypeEnum unitType;

    private enum actions{
        Attack,
        Taunt,
        Defend
    }


    void Start(){
        currHP = maxHP;
        currStamina = maxStamina;

        if (unitType == unitTypeEnum.Champion)
        {
            usesStamina = true;
        }

        if (unitType == unitTypeEnum.Enemy)
        {
            player = null;
        }
        else
        {
            player = GetComponent<Player>();
        }

        //ui = Instantiate(uiPrefab);
        //ui.transform.SetParent(GameObject.Find("Canvas").transform);
    }

    public void initTurn(){
        print("Name:\t" + unitName + "\tCurrent HP:\t" + currHP
            + "\tCurrent Defense:\t" + defense
            + "\tDefense Modifier:\t" + defensePts
            + "\tNumber of moves:\t" + maxNumMoves
            + "\tAttack Modifier:\t" + attackPts);

        if (usesStamina == true){
            currStamina -=1; 
        }

        numMovesRemaining = maxNumMoves;
    }

    public void takeDamage(int damagePts){
        print(unitName + " is taking " + damagePts + " damage. Defence: " + defense);
        currHP -= damagePts + defense;

        defense -= damagePts;

        if (defense < 0)
        {
            defense = 0;
        }

        if (currHP < 0)
        {
            currHP = 0;
        }
    }    
}
