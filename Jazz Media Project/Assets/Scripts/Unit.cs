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

   void Start(){
      currHP = maxHP;
      currStamina = maxStamina;
   }
}
