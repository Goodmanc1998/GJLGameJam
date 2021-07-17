using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text ScoreText;

    ScoreManager score;

    // Start is called before the first frame update
    void Start()
    {
        score = ScoreManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "SCORE : " + score.currentScore;
    }


}
