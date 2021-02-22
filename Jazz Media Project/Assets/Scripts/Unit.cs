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
    public int defenseModifier = 1;
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
        print("Name:\t" + unitName + "\tCurrent HP:\t" + currHP + "\tCurrent Defense:\t" + defense + "\tNumber of moves:\t" + maxNumMoves);
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
        defense += 1;
      
        numMovesRemaining -= 1;

    }

    public void takeDamage(int damagePts){

        if (damagePts > defense){
            damagePts -= defense;
            defense = 0;
            print("damage points\t" + damagePts);
            currHP -= damagePts;
        }
        else
        {
            defense -= attackPts;
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
