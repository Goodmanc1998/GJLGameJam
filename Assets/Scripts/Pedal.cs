using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedal : MonoBehaviour
{
    Vector3 mOffset;
    float mZCoord;
    float mXCoord;

    float startingY;
    public float maxDepth;
    [Range(0, 2)]
    public float returnSpeed;


    bool beingHeld = false;

    public float normalDist;


    private void Start()
    {
        startingY = transform.localPosition.y;
    }

    public float GetNormalizedSpeed()
    {

        float currDist = startingY - transform.position.y;

        return currDist / maxDepth; 
    }

    private void Update()
    {

        normalDist = GetNormalizedSpeed();


        float dist = transform.localPosition.y - startingY;

        if(!beingHeld && !Mathf.Approximately(0f, dist))
        {
            float delta = returnSpeed * Time.deltaTime;

            if (transform.position.y < startingY)
            {
                Vector3 nPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + delta, transform.localPosition.z);

                transform.localPosition = nPosition;
            }
            else
                normalDist = 0;

            
        }
    }



    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(transform.localPosition).z;
        mXCoord = Camera.main.WorldToScreenPoint(transform.localPosition).x;

        mOffset = gameObject.transform.localPosition - GetMouseAsWorldPoint();

        beingHeld = true;
    }

    void OnMouseDrag()
    {
        Vector3 nPosition = GetMouseAsWorldPoint() + mOffset;

        nPosition.y = Mathf.Clamp(nPosition.y, startingY - maxDepth, startingY);

        transform.localPosition = nPosition;


    }

    private void OnMouseUp()
    {
        beingHeld = false;
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        mousePoint.x = mXCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
