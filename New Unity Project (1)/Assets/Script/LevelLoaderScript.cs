using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    public Animator transition;
    public float transitiontime = 1f;
    public void LoadNextLevel(int indexScene) //Loads the next Level
    {
        StartCoroutine(LoadLevel(indexScene));
        //Wind sound
        if(indexScene == 1)
        {
            FindObjectOfType<AudioManager>().Play("Wind");
        }
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        //Play animation
        transition.Play("Start");
        //Wait
        yield return new WaitForSeconds(transitiontime);

        //Loads the next Level
        SceneManager.LoadScene(LevelIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "chambre_in")
        {
            LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (other.tag == "maison_in")
        {
            FindObjectOfType<AudioManager>().StopMusic("Wind");
            LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (other.tag == "chambre_out")
        {
            LoadNextLevel(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (other.tag == "maison_out")
        {
            LoadNextLevel(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
