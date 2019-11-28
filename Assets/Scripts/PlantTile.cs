using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantTile : MonoBehaviour
{
    public int health;
    public string name;
    public int atk = 0; //attack value for plant. 0 unless plant kills stuff on hit, b/c 1hp enemies
    public int growTime;
    public string description;

    // Start is called before the first frame update
    void Start()
    {
        name = this.name;
        getStats(name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getStats(string name){
         switch (name)
       {
           case "Sunflower":
                health = 1;
                growTime = 1;
                description = "A lovely, fast-growing flower, but they aren't very good defense!";
                break;
           case "Bush":
                //kills enemies on contact?
                health = 10;
                growTime = 3;
                description = "A big, spiky briar bush. Nothing gets past it.";
                atk = 10; //just needs to be >1
                break;
           case "Pumpkin":
                health = 6;
                growTime = 2;
                description = "A big, round plant that gets in the way of stuff. It also recharges mana!";
                break;
           case "Carrot":
                //if near carrot, ai are prioritized to go after the carrot?
                health = 3;
                growTime = 1;
                description = "A tasty little treat most critters can't refuse.";
                break;
           default:
                name = "";
                health = 1;
                growTime = 1;
                break;
       }
    }


}
