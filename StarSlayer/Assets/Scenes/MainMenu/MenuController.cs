using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSliderValue = null;

    [SerializeField] private float defaultVolume = 1.0f;

    [Header("Gameplay Setting")]
    [SerializeField] private TMP_Text ControllerSenTextValue = null;
    [SerializeField] private Slider ControllerSenSlider  = null;
    [SerializeField] private int defultSen = 4;
    public int mainControllerSen = 4;

    [Header("Toggle Settings")]
    [SerializeField] private Toggle invertYToggle = null;

    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;

    [Header("Level To Load")]
    public string _newGamelevel;
    private string levelToload;
    [SerializeField] private GameObject noSaveGameDialog = null;

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGamelevel);
    }

    public void loadGameDialoGYES()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToload = PlayerPrefs.GetString("savedLevel");
            SceneManager.LoadScene(levelToload);
        }
        else
        {
            noSaveGameDialog.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void volumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());

    }

    public void SetControllersen(float sensitivity)
    {
        mainControllerSen = Mathf.RoundToInt(sensitivity);
        ControllerSenTextValue.text = sensitivity.ToString("0");
    }

    public void GameplayApply()
    {
        if (invertYToggle.isOn)
        {
            PlayerPrefs.SetInt("masterInvertY", 1);
        }
        else
        {
            PlayerPrefs.SetInt("masterInvertY", 0);
        }
        PlayerPrefs.SetFloat("masterSen", mainControllerSen);
        StartCoroutine(ConfirmationBox());

    }

    public void Resetbutton(string MenuType)
    {
        if (MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSliderValue.value = defaultVolume;
            volumeTextValue.text = defaultVolume.ToString("0.0");
            volumeApply(); 
        }
        if (MenuType == "Gameplay")
        {
            ControllerSenTextValue.text = defultSen.ToString("0");
            ControllerSenSlider.value = defultSen;
            mainControllerSen = defultSen;
            invertYToggle.isOn= false;
            GameplayApply(); 
        }
    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }

}
