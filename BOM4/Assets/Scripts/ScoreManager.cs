using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text textScore;
    public float score;

    void Start()
    {
        score = 0;
        textScore.text = "Kill Count: " + score.ToString();
    }

    void Update()
    {
        textScore.text = score.ToString() + "Kill Count: ";
    }
}