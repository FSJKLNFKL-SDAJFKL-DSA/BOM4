using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class loadingPrefs : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] private bool canBeUsed = false;
    [SerializeField] private MenuController menuController;
     
    [Header("Volume Settings")]
    [SerializeField] private TMP_Text voluemTextValue = null;
    [SerializeField]private Slider SliderValue = null;




    [Header("Gameplay Setting")]
    [SerializeField] private TMP_Text ControllerSenTextValue = null;
    [SerializeField] private Slider ControllerSenSlider = null;

    [Header("Toggle Settings")]
    [SerializeField] private Toggle invertYToggle = null;

    public void Awake()
    {
        if (PlayerPrefs.HasKey("masterVolume"))
        {
            float localValue = PlayerPrefs.GetFloat("masterVolume");

            voluemTextValue.text = localValue.ToString("0.0");
            SliderValue.value = localValue;
            AudioListener.volume = localValue;
        }
        else
        {
            menuController.Resetbutton("Audio");
        }
        
    }

}
