using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
   public string unitName;

   public int maxHP;
   private int currHP;

   public int maxStamina;
   private int currStamina;

   public int numMoves;
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
      print("Name:\t" + unitName + "\tCurrent HP:\t" + currHP + "\tCuurent Defense:\t" + defense + "\tNumber of moves:\t" + numMoves);
      if (usesStamina == true){
         currStamina -=1; 
      }

      numMovesRemaining = numMoves;
   }

   public void attack(Unit target){
      target.takeDamage(attackPts);
      numMovesRemaining -= 1;
   }

   public void defend(){
      defense += 1;
      
      numMovesRemaining -= 1;

   }

   void takeDamage(int damagePts){

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
   }

   public void taunt(){
      numMoves += 1;
      numMovesRemaining = 0;

   }
}
