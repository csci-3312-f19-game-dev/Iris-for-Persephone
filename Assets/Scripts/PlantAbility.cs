using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlantAbility
{
      
   public int health;
   
   public int growTime; //just in case this is ever needed
   
   public string description; //for tooltips

   public double value; //if selling is ever implemented....

   public int cost;


   public PlantAbility(string name)
   {

                
       switch (name)
       {
           case "Sunflower":
                health = 1;
                growTime = 1;
                description = "A lovely, fast-growing flower, but they aren't very good defense!";
                value = 1.5;
                cost = 1;
                break;
           case "Bush":
                //kills enemies on contact?
                health = 10;
                growTime = 3;
                description = "A big, spiky briar bush. Nothing gets past it.";
                value = 0.0;
                cost = 8;
                break;
           case "Pumpkin":
                health = 6;
                growTime = 2;
                description = "A big, round plant that gets in the way of stuff. It also recharges mana!";
                value = 7;
                cost = 5;
                break;
           case "Carrot":
                //if near carrot, ai are prioritized to go after the carrot?
                health = 3;
                growTime = 1;
                description = "A tasty little treat most critters can't refuse.";
                value = 3;
                cost = 2;
                break;
           default:
                name = "";
                health = 1;
                growTime = 1;
                break;
       }


   }
}

//id 0 - dandelion/sunflower
// 1hp, 1d grow time, no abilities

//id 1 - bush
//10 hp, kills enemies on contact? 2 day grow time

//id 2
//