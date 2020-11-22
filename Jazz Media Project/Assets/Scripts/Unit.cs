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

   public bool isTurn;


   private int countPrint = 0;

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

}
