using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameClock : MonoBehaviour
{

    public TMP_Text shiftTime;
    public TMP_Text fairTime;

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

        //fairTime.color = new Color(fairTime.color.r, fairTime.color.g, fairTime.color.b, 0);
    }


    private void FixedUpdate()
    {
        SetUpDropTime();
        SetUpFairTime();
    }

    void SetUpFairTime()
    {
        string shiftSecondsString = "";
        int shiftSecondsInt = Mathf.RoundToInt(clock.GetSecondsShiftTime());

        if (shiftSecondsInt < 10)
        {
            shiftSecondsString = "0" + shiftSecondsInt;
        }
        else if(shiftSecondsInt <= 0)
        {
            shiftSecondsString = "00";
        }
        else
        {
            shiftSecondsString = shiftSecondsInt.ToString();
        }

        string shiftMinsString = "";
        int shiftMinsInt = Mathf.RoundToInt(clock.GetMinuetsShiftTime());

        if (shiftSecondsInt < 10)
        {
            shiftMinsString = "0" + shiftMinsInt;
        }
        else if (shiftSecondsInt <= 0)
        {
            shiftSecondsString = "00";
        }
        else
        {
            shiftMinsString = shiftMinsInt.ToString();
        }

        shiftTime.text = shiftMinsString + " : " + shiftSecondsString;
    }

    void SetUpDropTime()
    {
        string dpSecondsString = "";
        int dpSecondsInt = Mathf.RoundToInt(clock.GetSecondsFairTime());

        if (dpSecondsInt < 10)
        {
            dpSecondsString = "0" + dpSecondsInt;
        }
        else if (dpSecondsInt <= 0)
        {
            dpSecondsString = "00";
        }
        else
        {
            dpSecondsString = dpSecondsInt.ToString();
        }

        string dpMinsString = "";
        int dpMinsInt = Mathf.RoundToInt(clock.GetMinuetsFairTime());

        if (dpMinsInt < 10)
        {
            dpMinsString = "0" + dpMinsInt;
        }
        else if (dpMinsInt <= 0)
        {
            dpMinsString = "00";
        }
        else
        {
            dpMinsString = dpMinsInt.ToString();
        }

        fairTime.text = dpMinsString + " : " + dpSecondsString;


    }


    void Event(GameEvents currEvent)
    {

        if(currEvent == GameEvents.GAME_OVER)
        {
            fairTime.color = new Color(fairTime.color.r, fairTime.color.g, fairTime.color.b, 0);
            shiftTime.color = new Color(fairTime.color.r, fairTime.color.g, fairTime.color.b, 0);
        }


    }


}
