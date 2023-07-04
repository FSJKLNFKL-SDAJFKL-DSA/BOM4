using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class loadingPrefs : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] private MenuController menuController;
     
    [Header("Volume Settings")]
    [SerializeField] private TMP_Text voluemTextValue = null;
    [SerializeField]private Slider SliderValue = null;

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
