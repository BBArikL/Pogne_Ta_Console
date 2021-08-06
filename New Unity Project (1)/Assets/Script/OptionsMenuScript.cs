using System.Collections;
using System.Collections.Generic;
//using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using System.Linq;

public class OptionsMenuScript : MonoBehaviour
{
    public AudioMixer audiomixer; //Audio manager
    public Dropdown resolutionsdropdown;//Reference to the dropdown
    //public TMP_Dropdown resolutionsdrpodown; //TMPro_mesh dropdown
    Resolution[] resolutions; //List of available resolutions
    public PostProcessVolume volumeDaltonien;
    public PostProcessProfile Nothing;
    public PostProcessProfile Protanopia;
    public PostProcessProfile Deuteranopia;
    public PostProcessProfile Tritanopia;

    private void Start()
    {
        resolutions = Screen.resolutions; //Returns the available resolutions and store it in a array
        resolutionsdropdown.ClearOptions(); //Clears the options

        List<string> options = new List<string>(); //New Dynamic array of resolution arrays

        int CurrentResolutionindex = 0; //The index of the current resolution
        var resolutionfps = Screen.resolutions.Where(resolution => resolution.refreshRate == 60); //

        for (int i = 0; i < resolutions.Length; i++) //Format the resolution into text
        {
            string option = resolutions[i].width + "x" + resolutions[i].height; //Formatting
            options.Add(option); //Adding into the list

            //Finds the current resolution of the screen and defaults to it
            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                CurrentResolutionindex = i;
            }
        }

        resolutionsdropdown.AddOptions(options); //Adds all the resolutions option
        resolutionsdropdown.value = CurrentResolutionindex; //Defaults to current screen resolution
        resolutionsdropdown.RefreshShownValue(); //Refresh the dropdown
    }

    public void SetVolume(float Volume)
    {
        audiomixer.SetFloat("Volume", Mathf.Log10(Volume) * 20); //Set the volume
        //Debug.Log(Volume);
    }

    public void SetQuality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex); //Set graphics quality based on the index on the dropdown
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen; //Set the game fullscreen or not
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex]; //takes the resolution from the array
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); //Changes the resolution
    }

    public void SetDaltonism(int index)
    {
        if(volumeDaltonien == null)
        {
            PostProcessVolume volumedaltonien = new PostProcessVolume();
            volumeDaltonien.GetComponent<PostProcessVolume>();
        }

        if (index == 0)
        {
            volumeDaltonien.profile = Nothing;
            volumeDaltonien.GetComponent<PostProcessVolume>().enabled = false; //Forces Update
            volumeDaltonien.GetComponent<PostProcessVolume>().enabled = true;
        } else if (index == 1) {
            volumeDaltonien.profile = Protanopia;
            volumeDaltonien.GetComponent<PostProcessVolume>().enabled = false;
            volumeDaltonien.GetComponent<PostProcessVolume>().enabled = true;
        } else if (index == 2)
        {
            volumeDaltonien.profile = Deuteranopia;
            volumeDaltonien.GetComponent<PostProcessVolume>().enabled = false;
            volumeDaltonien.GetComponent<PostProcessVolume>().enabled = true;
        } else if (index == 3)
        {
            volumeDaltonien.profile = Tritanopia;
            volumeDaltonien.GetComponent<PostProcessVolume>().enabled = false;
            volumeDaltonien.GetComponent<PostProcessVolume>().enabled = true;
        }
    }
}
