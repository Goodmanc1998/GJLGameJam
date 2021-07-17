using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationArrow : MonoBehaviour
{
    Vector3 targetDir;
    Vector3 destinationPos;
    public float rotSpeed;

    public Color green;
    public Color red;
    public Color idleColour;

    public MeshRenderer navMesh;

    float nDistance;
    float currDistance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Car.Instance.currPassanger == null)
        {
            destinationPos = ClosestPassanger().position;
            navMesh.material.color = idleColour;
        }
        else
        {
            UpdateColour();
        }
            

        targetDir = destinationPos - transform.position;

        float rotDistance = rotSpeed * Time.deltaTime;

        Vector3 newRot = Vector3.RotateTowards(transform.forward, targetDir, rotDistance, 0);

        transform.rotation = Quaternion.LookRotation(newRot);



    }

    void UpdateColour()
    {
        nDistance = Car.Instance.GetPassanger().GetDistance();

        currDistance = Vector3.Distance(transform.position, Car.Instance.GetPassanger().GetDestination().position);

        float percent = currDistance / nDistance;

        Color nColour = Color.Lerp(red, green, percent);

        navMesh.material.color = nColour;
    }

    public Transform ClosestPassanger()
    {
        List<Passanger> currPassangers = PassangerManager.Instance.GetCurrentPassangers();

        Transform closest = null;
        float nDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        foreach (Passanger  p in currPassangers)
        {
            float dist = Vector3.Distance(p.transform.position, currentPos);

            if(dist < nDist)
            {
                closest = p.transform;
                nDist = dist;

            }
        }

        return closest;
        
    }
    
    public void UpdateDestination(Transform newPos)
    {
        Vector3 pos = new Vector3(newPos.position.x, transform.position.y, newPos.position.z);

        destinationPos = pos;
    }
    
}
