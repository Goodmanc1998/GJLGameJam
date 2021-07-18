using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{

    public LocationPointer pointerArrow;

    bool occupied = false;

    public enum locationArea
    {
        Downtown,
        Residential,
        Bank,
        Gym

    }

    public locationArea location;

    public locationArea GetLocationArea()
    {
        return location;
    }

    public enum locationType
    {
        Starting,
        Finishing,
        Both
    };

    public locationType currentLocation;

    public Transform GetLocationTransform()
    {
        return transform;
    }

    public locationType GetLocationType()
    {
        return currentLocation;
    }

    public bool GetOccupied()
    {
        return occupied;
    }

    public void SetOccupied(bool nBool)
    {
        occupied = nBool;

        if (nBool)
        {
            pointerArrow.UpdatePassanger();
        }
        else
        {
            SetUnActive();
        }
    }

    public void SetDestination()
    {
        pointerArrow.UpdateDestination();
    }

    public void SetUnActive()
    {
        pointerArrow.UpdateUnActive();
    }


}
