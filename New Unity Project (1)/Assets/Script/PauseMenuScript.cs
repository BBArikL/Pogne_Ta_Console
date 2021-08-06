using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool isPaused = false; //If the game is paused
    public string MenuSceneName; //The name of the menu scene
    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame(1);
            }
        }   
    }

    public void ResumeGame()
    {
        isPaused = false;
        PauseMenuUI.SetActive(isPaused);
        Time.timeScale = 1f; //Unfreeze game
    }

    void PauseGame(int trigger)
    {
        isPaused = true;
        PauseMenuUI.SetActive(isPaused);
        Time.timeScale = 0; //Freeze Game
    }

    public void LoadMenu()
    {
        isPaused = false; //Unpause the game
        Time.timeScale = 1f; //Unfreeze Game
        FindObjectOfType<AudioManager>().StopMusic("Wind");
        SceneManager.LoadScene(MenuSceneName);//Gets back to menu
    }

    public void QuitGame()
    {
        //Quit the game
        Debug.Log("QUIT!"); //Just for Unity Editor
        Application.Quit(); //Quits the game in the application
    }
}
