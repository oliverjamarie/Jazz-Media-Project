using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;

    public int maxHP;
    public int currHP;

    public int maxStamina;
    private int currStamina;

    public int maxNumMoves;
    public int numMovesRemaining;

    public int defense;
    public int defenseModifier;
    public int attackPts;

    //public bool isTurn;
    public bool usesStamina;

    public enum unitTypeEnum{
        Player,
        Creature,
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
    }

    public void initTurn(){
        print("Name:\t" + unitName + "\tCurrent HP:\t" + currHP
            + "\tCurrent Defense:\t" + defense
            + "\tNumber of moves:\t" + maxNumMoves
            + "\tAttack Modifier:\t" + attackPts);
        if (usesStamina == true){
            currStamina -=1; 
        }

        numMovesRemaining = maxNumMoves;
    }

    public void attack(Unit target, int damage){
        print(unitName + " is attacking with " + attackPts + " base attack points" );
        target.takeDamage(attackPts + damage);
        numMovesRemaining -= 1;
    }

    public void defend(){
        print(unitName + " is defending");
        defense += defenseModifier;
      
        numMovesRemaining -= 1;

    }

    void takeDamage(int damagePts){
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

    public void taunt(){
        print(unitName + " is taunting");
        maxNumMoves += 1;
        numMovesRemaining = 0;
    }
}
