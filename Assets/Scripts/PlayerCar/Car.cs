using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public CarController Controller;
    public NavigationArrow navigation;

    public Passanger currPassanger;

    private static Car _instance;
    public static Car Instance
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

    private void Start()
    {
        
    }

    private void Update()
    {
        if(currPassanger == null)
        {

        }
        
    }

    public void SetPassanger(Passanger nPassanger)
    {
        currPassanger = nPassanger;
        if(currPassanger != null)
            navigation.UpdateDestination(currPassanger.GetDestination());
    }

    public Passanger GetPassanger()
    {
        return currPassanger;
    }


}
