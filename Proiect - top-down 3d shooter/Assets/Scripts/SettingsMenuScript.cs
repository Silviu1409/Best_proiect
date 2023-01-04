using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenuScript : MonoBehaviour
{
    public AudioMixer audioMixer;

    private Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public Toggle fullscreenToggle;
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == Screen.currentResolution.refreshRate).ToArray();
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        //int currentResolutionIndex = PlayerPrefs.GetInt("Quality");
        for (int i = 0; i < resolutions.Length; i++)
        {
           // if (resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            //{
                string option = resolutions[i].width + " x " + resolutions[i].height + " " +
                                resolutions[i].refreshRate + "Hz";
            

            options.Add(option);
            //}

            //if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        int qualitySetting = PlayerPrefs.GetInt("Quality");
        qualityDropdown.value = qualitySetting;

        int fullscreenSetting = PlayerPrefs.GetInt("isFullscreen");
        if (fullscreenSetting == 0)
        {
            fullscreenToggle.isOn = false;
        }
        else
        {
            fullscreenToggle.isOn = true;
        }

        float masterVolumeLevel = PlayerPrefs.GetFloat("masterVolume");
        masterVolumeSlider.value = masterVolumeLevel;
        float musicVolumeLevel = PlayerPrefs.GetFloat("musicVolume");
        musicVolumeSlider.value = musicVolumeLevel;

    }
    public void SetMasterVolume(float volume)
    {
        //audioMixer.SetFloat("volumeParameter", volume);
        audioMixer.SetFloat("masterVolParameter", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        //audioMixer.SetFloat("volumeParameter", volume);
        audioMixer.SetFloat("musicVolParameter", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
        audioMixer.FindMatchingGroups("");
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("Quality", qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        if (isFullscreen)
        {
            PlayerPrefs.SetInt("isFullscreen",1);
        }
        else
        {
            PlayerPrefs.SetInt("isFullscreen", 0);
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        
    }

}
