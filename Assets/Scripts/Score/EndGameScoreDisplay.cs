using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScoreDisplay : MonoBehaviour
{

    public GameObject menuObject;

    public Text totalScoretxt;
    public Text totalPassangers;

    public Button retryBtn;
    public Button menuBtn;



    private void OnEnable()
    {
        GameManager.onGameEvent += Event;
    }

    private void OnDisable()
    {
        GameManager.onGameEvent -= Event;
    }

    // Start is called before the first frame update
    void Start()
    {
        menuObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Event(GameEvents currEvent)
    {
        if (currEvent != GameEvents.GAME_OVER)
            return;

        menuObject.SetActive(true);


        totalScoretxt.text = "Total Score : " + Mathf.RoundToInt(ScoreManager.Instance.currentScore);

        totalPassangers.text = "Total Passangers : " + ScoreManager.Instance.passangersDroppedOff;

    }
}
