using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
   public string unitName;

   public int maxHP;
   public int currHP;

   public int maxStamina;
   public int currStamina;

   public int numMoves;
   public int numMovesRemaining;

   public int defense;
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
      if (usesStamina == true){
         currStamina -=1; 
      }

      numMovesRemaining = numMoves;
   }

   public void attack(Unit target){
      print(unitName + " Is Attacking " + target.unitName + "\tHP Left: " + target.currHP);
      target.takeDamage(attackPts);
      numMovesRemaining -= 1;
   }

   public void defend(){
      defense += 1;
      print(unitName + " Is Defending. Current Defense Points " + defense);
      numMovesRemaining -= 1;

   }

   public void takeDamage(int damagePts){

      if (damagePts > defense){
         damagePts -= defense;
         defense = 0;
         
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
