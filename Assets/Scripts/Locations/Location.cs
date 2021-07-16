using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string name;
    bool occupied = false;

    public enum locationType
    {
        Starting,
        Finishing,
        Both
    };

    public locationType currentLocation;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    }


}
