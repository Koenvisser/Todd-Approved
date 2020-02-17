using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsScript : MonoBehaviour
{
    public Animator animator;

    public void Back() {
        animator.SetTrigger("SettingsTrigger");
    }

    public AudioMixer audioMixer;

    public Slider resolutionSlider;
    public Slider fullscreenSlider;
    public Slider graphicsSlider;
    public Slider volumeSlider;
    public GameObject resolutionText;

    Resolution[] resolutions;
    private void Start()
    {
        if (Screen.fullScreen == true)
        { fullscreenSlider.value = 1f; }
        resolutions = Screen.resolutions;
        resolutionSlider.maxValue = resolutions.Length - 1;
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionSlider.value = currentResolutionIndex;
        DisplayResolution(resolutionSlider.value);
    }

    // Here we change the overal volume of the game
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void DisplayResolution(float resolutionIndex)
    {
        Resolution resolution = resolutions[(int)resolutionIndex];
        resolutionText.GetComponent<TextMeshProUGUI>().SetText(resolution.width + "x" + resolution.height);
    }

    public void SetResolution()
    {
        float resolutionIndex = resolutionSlider.value;
        Resolution resolution = resolutions[(int)resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void FullScreen(float on)
    {
        bool full = false;
        if (on > 0)
        {
            full = true;
        }
        Screen.fullScreen = full;
    }
}
