using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassangerManager : MonoBehaviour
{

    public int maxPassangerAmount;
    public float despawnDistance;
    public float spawnDistance;
    int currentPassangerAmount;

    public float minCarDistance;
    public float minCarSpeed;


    LocationManager locationMGR;
    public GameObject passanger;

    private static PassangerManager _instance;
    public static PassangerManager Instance
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
        locationMGR = LocationManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateAvailablePassangers()
    {
        List<Passanger> currPassangers = GetCurrentPassangers();

        int removed = 0;

        foreach (Passanger p in currPassangers)
        {
            if(Vector3.Distance(p.transform.position, Car.Instance.transform.position) > despawnDistance)
            {
                p.GetStartingLocation().SetOccupied(false);
                Destroy(p.gameObject);
                removed++;
            }
        }

        if (removed > 0)
        {
            for (int i = 0; i <= removed - 1; i++)
            {
                CreatePassanger();
            }
        }

        int missing = maxPassangerAmount - currPassangers.Count;

        if (missing > 0)
        {
            for (int i = 0; i < missing; i++)
            {
                CreatePassanger();
            }

        }

    }

    void CreatePassanger()
    {
        GameObject nPassanger = Instantiate(passanger, new Vector3(0, -50, 0), Quaternion.identity);
    }

    void Event(GameEvents currEvent)
    {
        switch(currEvent)
        {
            case GameEvents.LOCATIONS_COLLECTED:
                FirstSpawn();
                break;
            case GameEvents.PASSANGER_DROPPED_OFF:
                UpdateAvailablePassangers();
                break;
            default:
                break;
        }
    }

    void FirstSpawn()
    {
        for (int i = 0; i < maxPassangerAmount; i++)
        {
            CreatePassanger();
        }

        GameManager.onGameEvent(GameEvents.PLAYER_ACTIVE);
    }

    public List<Passanger> GetCurrentPassangers()
    {
        GameObject[] passangerObject = GameObject.FindGameObjectsWithTag("Passanger");

        List<Passanger> currPass = new List<Passanger>();

        foreach (GameObject g in passangerObject)
        {
            currPass.Add(g.GetComponent<Passanger>());
        }
        return currPass;
    }

    public float GetMaxSpawnDistance()
    {
        return spawnDistance;
    }

}
