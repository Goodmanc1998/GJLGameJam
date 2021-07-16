using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameEvents
{
    GAME_LOAD,
    LOCATIONS_COLLECTED,
    PASSANGERS_CREATED,
    PLAYER_CREATED,
    PASSANGER_DROPPED_OFF
}

public class GameManager : MonoBehaviour
{
    public delegate void GameEvent(GameEvents gameEvent);
    public static GameEvent onGameEvent;

    private static GameManager _instance;
    public static GameManager Instance
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

    }

    // Start is called before the first frame update
    void Start()
    {
        onGameEvent(GameEvents.GAME_LOAD);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
