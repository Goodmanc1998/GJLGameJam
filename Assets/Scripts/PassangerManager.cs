using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassangerManager : MonoBehaviour
{

    public int maxPassangerAmount;
    public float despawnDistance;
    int currentPassangerAmount;

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

        GameManager.onGameEvent += Event;
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
                Destroy(p.gameObject);
                removed++;
            }
        }

        Debug.Log("Amount Removed : " + removed);

        if(removed > 0)
        {
            for (int i = 0; i <= removed - 1; i++)
            {
                CreatePassanger();
            }
        }



    }

    void CreatePassanger()
    {
        Debug.Log("CREATE PASSANGER");
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

}
