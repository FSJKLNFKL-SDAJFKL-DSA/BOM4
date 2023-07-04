using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreDisplay : MonoBehaviour
{
    public TMP_Text finalScoreDisplay;

    void Start()
    {
        finalScoreDisplay.text = "Score: " + ScoreManager.score.ToString();
    }



}
