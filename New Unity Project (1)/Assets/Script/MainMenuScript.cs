using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void QuitGame()
    {
        //Quit the game
        Debug.Log("QUIT!"); //Just for Unity Editor
        Application.Quit(); //Quits the game in the application
    }
}
