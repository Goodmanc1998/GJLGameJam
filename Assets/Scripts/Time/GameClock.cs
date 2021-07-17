using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClock : MonoBehaviour
{

    public float ShiftLength;

    public float shiftTimeLeft;

    public float increasePerDistance;

    float dropOffTime;

    public bool timeStart = true;

    public Vector2 gameClock;

    private static GameClock _instance;
    public static GameClock Instance
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

    // Start is called before the first frame update
    void Start()
    {
        shiftTimeLeft = ShiftLength;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeStart)
        {
            shiftTimeLeft -= Time.deltaTime;
        }

        if(timeStart && Car.Instance.GetPassanger() != null)
        {
            dropOffTime -= Time.deltaTime;
        }

        if(shiftTimeLeft <= 0 && timeStart || dropOffTime <= 0 && Car.Instance.GetPassanger() != null)
        {
            timeStart = false;
            GameManager.onGameEvent(GameEvents.GAME_OVER);
        }


    }

    public void IncreaseTime(float distance)
    {
        float nTime = distance * increasePerDistance;

        Debug.Log("New Time : " + nTime);

        dropOffTime = nTime;
    }

    public float GetMinuetsShiftTime()
    {
        return Mathf.Floor(shiftTimeLeft / 60);
    }

    public float GetSecondsShiftTime()
    {
        return shiftTimeLeft % 60;
    }

    public float GetMinuetsFairTime()
    {
        return Mathf.Floor(dropOffTime / 60);
    }

    public float GetSecondsFairTime()
    {
        return dropOffTime % 60;
    }
}
