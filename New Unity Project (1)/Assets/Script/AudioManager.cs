using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    private void Awake()
    {
        //Makes sure that there is only one instance of AudioManager
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); //Doesnt destroy the audiomanager while changing scenes

        //Loop dans tout les sons et les ajoute dans le jeu
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.AudioMixer;
        }
    }

    private void Start()
    {
        Play("Theme"); //Plays the theme
    }

    public void Play(string nameclip)
    {
        Sound s = Array.Find(sounds, sound => sound.name == nameclip); //Find in the sound Array the clip with the good name

        if (s != null)
        {
            s.source.Play(); //plays the sound
        }
        else
        {
            Debug.LogWarning("Clip "+'"'+nameclip+'"'+" not found. The name of the clip might not be good or you forgot to add it.");
        }
    }

    public void StopMusic(string nameclip)
    {
        Sound s = Array.Find(sounds, sound => sound.name == nameclip); //Find in the sound Array the clip with the good name

        if (s != null)
        {
            s.source.Stop(); //Stops the sound
        }
        else
        {
            Debug.LogWarning("Clip " + '"' + nameclip + '"' + " not found. The name of the clip might not be good or you forgot to add it.");
        }
    }

    public bool CheckIfPlaying(string nameclip)
    {
        Sound s = Array.Find(sounds, sound => sound.name == nameclip); //Find in the sound Array the clip with the good name

        if (s != null)
        {
            return s.source.isPlaying;
        }
        else
        {
            Debug.LogWarning("Clip " + '"' + nameclip + '"' + " not found. The name of the clip might not be good or you forgot to add it.");
            return false;
        }
    }
}
