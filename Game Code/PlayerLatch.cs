using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLatch : MonoBehaviour
{
    //Keeps the menu at the players side
    // resets transformation when strays to far

    public Transform player;
    public Transform menu;
    public GameObject mainMenu;


    void Start()
    {
       //mainMenu = GameObject.DontDestroyOnLoad;
        menu = gameObject.GetComponent<Transform>();
        player = gameObject.GetComponent<Transform>();
    }

   
    void Update()
    {

        //use update to keep it following the player 
        //then if grabbed start coroutine that handles menu function
        
            if (Vector3.Distance(menu.position, player.position) >= 0.1f)
            {
            Debug.Log(player + "I know what this is");
            Debug.Log(menu + "I also know what this is");
                menu.position = Vector3.Lerp(menu.position, player.position + -menu.up * 0.32f,  Time.deltaTime);
                menu.position = Vector3.Lerp(menu.position, player.position  + (-menu.right * 0.000001f), Time.deltaTime);
            

            }
    }
}
