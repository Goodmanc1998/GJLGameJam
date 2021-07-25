using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public float currentScore;
    public float passangersPickedUp;
    public float passangersDroppedOff;
    public float totalPassangerDistance;
    public float timeLeftOver;

    private static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        
    }

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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseScore(float nScore)
    {
        StartCoroutine(LerpScore(nScore));

        Debug.Log("INCREASING SCORE : " + nScore);
    }

    IEnumerator LerpScore(float nScore)
    {
        float timePassed = 0;

        float startingScore = currentScore;
        float changedScore = currentScore + nScore;

        while(timePassed < 2)
        {
            currentScore = Mathf.Lerp(startingScore, changedScore, timePassed / 2);

            timePassed += Time.deltaTime;

            yield return null;
        }

        currentScore = changedScore;
    }

    public void IncreaseScoreTime(float nScore)
    {
        timeLeftOver += nScore;

        if (passangersDroppedOff == 0)
            IncreaseScore(nScore);

        IncreaseScore(nScore * passangersDroppedOff);

    }

    public void IncreaseDistanceTravelled(float nScore)
    {
        totalPassangerDistance += nScore;

        IncreaseScore(nScore * passangersDroppedOff);
    }

    public void Event (GameEvents currEvent)
    {
        if (currEvent == GameEvents.ENTERING_CAR)
            passangersPickedUp++;

        if (currEvent == GameEvents.PASSANGER_DROPPED_OFF)
        {
            passangersDroppedOff++;
            IncreaseScoreTime(GameClock.Instance.GetFairTime());
        }


    }
}
