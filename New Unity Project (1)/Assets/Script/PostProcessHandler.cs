using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessHandler: MonoBehaviour
{
    public static PostProcessHandler instance;

    private void Awake()
    {
        //Makes sure that there is only one instance of this PostProssecing
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); //Doesnt destroy the audiomanager while changing scenes
    }
}
