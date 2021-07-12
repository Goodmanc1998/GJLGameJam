using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedal : MonoBehaviour
{

    public float maxDepth;
    public float returnSpeed;
    float dist = 0;

    bool beingHeld = false;

    Vector3 startingLocalPos;
    Vector3 screenPoint;
    Vector3 offset;

    

    private void Start()
    {
        startingLocalPos = transform.position;
    }

    public float GetNormalizedDistance()
    {
        return dist / maxDepth;
    }

    private void Update()
    {

        dist = startingLocalPos.y - transform.position.y;

        //Debug.Log("STARTING : " +startingLocalPos.y);
        //Debug.Log("CURRENT : " + transform.position.y);


        if (!beingHeld && dist > 0)
        {
            float delta = returnSpeed * Time.deltaTime;

            Vector3 nPos = new Vector3(transform.position.x, transform.position.y + delta, transform.position.z);

            nPos.y = Mathf.Clamp(nPos.y, startingLocalPos.y - maxDepth, startingLocalPos.y);

            transform.position = nPos;
        }
        else if (dist < 0.05)
        {
            dist = 0;
            Debug.Log("CLOSE ENOUGH");
        }

        Debug.Log("STARTING : " + dist);

    }

    private void OnMouseDown()
    {
        beingHeld = true;

        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        curPosition.y = Mathf.Clamp(curPosition.y, startingLocalPos.y - maxDepth, startingLocalPos.y);

        transform.position = curPosition;
    }

    private void OnMouseExit()
    {
        beingHeld = false;
    }
}
