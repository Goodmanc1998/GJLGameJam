using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{

    List<Location> allLocations = new List<Location>();
    List<Location> startingLocations = new List<Location>();
    List<Location> finishingLocations = new List<Location>();

    private static LocationManager _instance;
    public static LocationManager Instance
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
        GameManager.onGameEvent += GetLocations;
    }

    private void OnDisable()
    {
        GameManager.onGameEvent -= GetLocations;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetLocations(GameEvents currEvent)
    {
        if (currEvent != GameEvents.GAME_LOAD)
            return;

        GameObject[] locations = GameObject.FindGameObjectsWithTag("Location");

        foreach (GameObject currObject in locations)
        {
            Location currLocation = currObject.GetComponent<Location>();

            allLocations.Add(currLocation);

            if (currLocation.GetLocationType() == Location.locationType.Starting || currLocation.GetLocationType() == Location.locationType.Both)
            {
                startingLocations.Add(currLocation);
            }
                

            if (currLocation.GetLocationType() == Location.locationType.Finishing || currLocation.GetLocationType() == Location.locationType.Both)
                finishingLocations.Add(currLocation);

        }

        GameManager.onGameEvent(GameEvents.LOCATIONS_COLLECTED);
    }

    public Location GetRandomStartingLocation()
    {
        Transform playerPos = Car.Instance.transform;

        Location locationToReturn = null;

        while (locationToReturn == null)
        {
            int rndNo = Random.Range(0, startingLocations.Count);

            float distToPlayer = Vector3.Distance(startingLocations[rndNo].transform.position, playerPos.position);

            if (!startingLocations[rndNo].GetOccupied()  && distToPlayer > 20)
            {
                if (distToPlayer < PassangerManager.Instance.GetMaxSpawnDistance())
                {
                    locationToReturn = startingLocations[rndNo];
                }
                
            }
        }

        return locationToReturn;
    }

    public Location GetRandomFinishingLocation(Location startLoc)
    {
        Location locationToReturn = null;

        while(locationToReturn == null)
        {
            int rndNo = Random.Range(0, finishingLocations.Count);

            if(startLoc != finishingLocations[rndNo] && Vector3.Distance(startLoc.transform.position, finishingLocations[rndNo].transform.position) < 700)
                locationToReturn = finishingLocations[rndNo];
        }
        
        return locationToReturn;
    }




}
