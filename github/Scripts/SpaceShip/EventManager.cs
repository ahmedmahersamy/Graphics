using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {
    public delegate void StartGameDelegate();
    public static StartGameDelegate onStartGame;

    public static void StartGame()
    {
        Debug.Log("start game!");
     /*   if(onStartGame != null)
        {
            onStartGame();

        }*/
    }




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
