using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passanger : MonoBehaviour
{

    Location startingLocation = null;
    Location finishingLocation;

    float minCarDistance;
    float minCarSpeed;

    float travelDist;

    bool inCar = false;

    Rigidbody player;

    // Start is called before the first frame update
    void Start()
    {
        SetLocations();

        player = Car.Instance.GetComponent<Rigidbody>();

        minCarDistance = PassangerManager.Instance.minCarDistance;
        minCarSpeed = PassangerManager.Instance.minCarSpeed;

    }

    private void OnEnable()
    {
        GameManager.onGameEvent += CheckCar;
    }

    private void OnDisable()
    {
        GameManager.onGameEvent -= CheckCar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(inCar)
        {

            transform.position = (player.position + (Vector3.up * 10));

            if (Vector3.Distance(player.position, finishingLocation.GetLocationTransform().position) < minCarDistance)
            {
                if (player.velocity.magnitude < minCarSpeed)
                {
                    DropOff();
                }
            }

        } 
    }




    void CheckCar(GameEvents currEvent)
    {

        if (currEvent != GameEvents.CAR_HORN)
            return;

        if(player.GetComponent<Car>().GetPassanger() == null)
        {
            if (Vector3.Distance(transform.position, player.position) < minCarDistance)
            {
                if (player.velocity.magnitude < minCarSpeed)
                {
                    StartCoroutine(GettingInCar());

                    
                }
            }
    }

        
    }

    IEnumerator GettingInCar()
    {
        float currScale = transform.localScale.y;

        GameClock.Instance.IncreaseTime(travelDist);

        while (currScale > 0)
        {
            float scaleChange = 0.2f * Time.deltaTime;

            currScale -= scaleChange;

            transform.localScale = new Vector3(currScale, currScale, currScale);
        }

        //GET IN CAR
        player.GetComponent<Car>().SetPassanger(this);
        inCar = true;
        finishingLocation.SetDestination();
        startingLocation.SetOccupied(false);

        GameManager.onGameEvent(GameEvents.ENTERING_CAR);


        yield return null;

    }

    void DropOff()
    {
        player.GetComponent<Car>().SetPassanger(null);
        transform.tag = "Untagged";

        finishingLocation.SetUnActive();

        GameManager.onGameEvent(GameEvents.PASSANGER_DROPPED_OFF);
        ScoreManager.Instance.IncreaseDistanceTravelled(travelDist);
        
        Debug.Log("IVE BEEN DROPPED OFF");
        Destroy(this.gameObject);
    }

    void SetLocations()
    {
        startingLocation = LocationManager.Instance.GetRandomStartingLocation();

        startingLocation.SetOccupied(true);

        finishingLocation = LocationManager.Instance.GetRandomFinishingLocation(startingLocation);

        transform.position = startingLocation.GetLocationTransform().position;
        transform.rotation = startingLocation.transform.rotation;

        travelDist = Vector3.Distance(startingLocation.transform.position, finishingLocation.transform.position);

    }

    public Location GetFinishingLocation()
    {
        return finishingLocation;
    }

    public Location GetStartingLocation()
    {
        return startingLocation;
    }

    public Transform GetDestination()
    {
        return finishingLocation.transform;
    }

    public float GetDistance()
    {
        return travelDist;
    }

}
