using DevionGames.InventorySystem;
using DevionGames.UIWidgets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DevionGames;
using System;

public class Tree : MonoBehaviour
{
    public int health = 100;
    // Update is called once per frame
    void Update()
    {
        if(health <=0)
        {
            //instanciate random class
            System.Random rnd = new System.Random();
            //a random number between 1 and 3 is rnd.Next(1,4);
            InventoryManager.Notifications.gatheredItem.Show(rnd.Next(1, 4).ToString(), UnityTools.ColorString("Wood", Color.white));
            Destroy(gameObject);
        }
    }
}
