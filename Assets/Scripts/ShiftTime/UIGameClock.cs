using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameClock : MonoBehaviour
{

    public Text shiftTime;
    public Text fairTime;

    GameClock clock;

    private void Awake()
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
        clock = GameClock.Instance;

        fairTime.color = new Color(fairTime.color.r, fairTime.color.g, fairTime.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        int ShiftM = Mathf.RoundToInt(clock.GetMinuetsShiftTime());
        int shiftS = Mathf.RoundToInt(clock.GetSecondsShiftTime());

        int FairM = Mathf.RoundToInt(clock.GetMinuetsFairTime());
        int FairS = Mathf.RoundToInt(clock.GetSecondsFairTime());

        if (shiftS < 10)
        {
            shiftTime.text = ShiftM + " : 0" + shiftS;
        }
        else
        {
            shiftTime.text = ShiftM + " : " + shiftS;
        }

        if (FairS < 10)
        {
            fairTime.text = FairM + " : 0" + FairS;
        }
        else
        {
            fairTime.text = FairM + " : " + FairS;
        }

    }

    
    void Event(GameEvents currEvent)
    {
        if (currEvent == GameEvents.ENTERING_CAR)
            fairTime.color = new Color(fairTime.color.r, fairTime.color.g, fairTime.color.b, 1);

        if (currEvent == GameEvents.PASSANGER_DROPPED_OFF || currEvent == GameEvents.GAME_OVER)
            fairTime.color = new Color(fairTime.color.r, fairTime.color.g, fairTime.color.b, 0);


    }


}
