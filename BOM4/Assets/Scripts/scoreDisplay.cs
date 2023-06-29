using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreDisplay : MonoBehaviour
{
    private GameObject scoredisplay;
    private TMP_Text scoreText;
    private ScoreManager scoreManager;
    void Start()
    {
        scoredisplay = GameObject.Find("Score");
        scoreText = scoredisplay.GetComponent<TMP_Text>();
        ScoreManager sm = scoreManager.GetComponent<ScoreManager>();
        scoreText.text = "Score:" + sm.score.ToString();
    }
}
