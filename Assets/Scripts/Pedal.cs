using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedal : MonoBehaviour
{
    public Transform pedalPoint;
    Vector3 heightPoint;

    public float maxDepth;
    public float returnSpeed;
    float dist = 0;

    bool beingHeld = false;

    Vector3 screenPoint;
    Vector3 offset;

    

    private void Start()
    {
        transform.position = pedalPoint.position + (pedalPoint.up * maxDepth);
    }

    public float GetNormalizedDistance()
    {
        return dist / maxDepth;
    }

    private void Update()
    {
        heightPoint = pedalPoint.position + (pedalPoint.up * maxDepth);

        dist = heightPoint.y - transform.position.y;

        if (!beingHeld && dist > 0)
        {
            float delta = returnSpeed * Time.deltaTime;

            Vector3 nPos = new Vector3(transform.position.x, transform.position.y + delta, transform.position.z);

            if(heightPoint.y > pedalPoint.position.y)
            {
                nPos.x = Mathf.Clamp(nPos.x, pedalPoint.position.x, heightPoint.x);
                nPos.y = Mathf.Clamp(nPos.y, pedalPoint.position.y, heightPoint.y);
                nPos.z = Mathf.Clamp(nPos.z, pedalPoint.position.z, heightPoint.z);

            }
            else
            {
                nPos.x = Mathf.Clamp(nPos.x, heightPoint.x, pedalPoint.position.x);
                nPos.y = Mathf.Clamp(nPos.y, heightPoint.y, pedalPoint.position.y);
                nPos.z = Mathf.Clamp(nPos.z, heightPoint.z, pedalPoint.position.z);
            }     

            transform.position = nPos;
        }
        else if (dist < 0.05)
        {
            dist = 0;
        }
    }

    private void OnMouseDown()
    {
        beingHeld = true;

        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z));

        Debug.Log("Being Held");
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        curPosition.y = Mathf.Clamp(curPosition.y, pedalPoint.position.y, heightPoint.y);

        transform.position = curPosition;
    }

    private void OnMouseExit()
    {
        beingHeld = false;
    }
}
