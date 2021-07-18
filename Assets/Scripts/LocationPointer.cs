using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationPointer : MonoBehaviour
{

    public Color desination;
    public Color passanger;
    public Color unActive;

    MeshRenderer meshRenderer;


    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
        meshRenderer.material.color = unActive;
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).GetChild(0).transform.RotateAround(transform.position, transform.up, 1);
    }

    public void UpdateDestination()
    {
        meshRenderer.material.color = desination;
        Debug.Log("SET TO DESTINATION");
    }

    public void UpdatePassanger()
    {
        meshRenderer.material.color = passanger;
        Debug.Log("SET TO Passanger");

    }

    public void UpdateUnActive()
    {
        meshRenderer.material.color = unActive;
        Debug.Log("SET TO Unactive");


    }



}
