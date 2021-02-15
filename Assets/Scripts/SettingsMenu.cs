// Menu for controlling resolution and save data

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    Resolution[] resolution;
    public Dropdown resolutionDropdown;

    void Start()
    {
        resolution = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolution.Length; i++) {
            string option = resolution[i].width + " x " + resolution[i].height;
            options.Add(option);

            if (resolution[i].width == Screen.currentResolution.width && 
                resolution[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    // public void setResolution(int resolutionIndex)
    // {
    //     resolutionDropdown res = resolution[resolutionIndex];
    //     Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    // }
}
