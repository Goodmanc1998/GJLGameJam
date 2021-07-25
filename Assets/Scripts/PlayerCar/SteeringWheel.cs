using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SteeringWheel : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip horn;
    public float hornDistance;
    float currHornDist;

    public float maxTurningAngle;
    public float turningSpeed;

    public float wheelAngle = 0f;
    float prevWheelAngle = 0f;

    bool wheelBeingHeld = false;

    Vector2 centerPoint;

    public bool active = true;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = horn;
    }

    // Update is called once per frame
    void Update()
    {
        //if not being held and not 0
        if(!wheelBeingHeld && !Mathf.Approximately(0f, wheelAngle))
        {
            //Returning movement speed
            float deltaAngle = turningSpeed * Time.deltaTime;

            if (Mathf.Abs(deltaAngle) > Mathf.Abs(wheelAngle))
                wheelAngle = 0f;
            else if (wheelAngle > 0f)
                wheelAngle -= deltaAngle;
            else
                wheelAngle += deltaAngle;
        }

        //Rotating the wheel
        transform.localEulerAngles = Vector3.back * wheelAngle;

        if (currHornDist < hornDistance)
            PlayHorn();

    }

    //Getters for wheel angle and normalized angle
    public float GetAngle()
    {
        return wheelAngle;
    }

    public float GetNormalAngle()
    {
        return wheelAngle / maxTurningAngle;
    }

    //Unity Built in Mouse functions
    private void OnMouseDrag()
    {
        Vector2 pointerPos = Input.mousePosition;

        currHornDist = Vector2.Distance(pointerPos, centerPoint);

        float wheelNewAngle = Vector2.Angle(Vector2.up, pointerPos - centerPoint);
        //Check distance from center
        if (Vector2.Distance(pointerPos, centerPoint) > 20f)
        {
            //Checking which way to rotate wheel
            if (pointerPos.x > centerPoint.x)
                wheelAngle += wheelNewAngle - prevWheelAngle;
            else
                wheelAngle -= wheelNewAngle - prevWheelAngle;
        }
        // Make sure wheel angle never exceeds maximumSteeringAngle
        wheelAngle = Mathf.Clamp(wheelAngle, -maxTurningAngle, maxTurningAngle);
        prevWheelAngle = wheelNewAngle;
    }

    private void OnMouseDown()
    {
        Vector2 pointerPos = Input.mousePosition;

        wheelBeingHeld = true;

        centerPoint = Camera.main.WorldToScreenPoint(transform.position);

        prevWheelAngle = Vector2.Angle(Vector2.up, pointerPos - centerPoint);

        currHornDist = Vector2.Distance(pointerPos, centerPoint);
    }

    private void OnMouseUp()
    {
        wheelBeingHeld = false;
    }


    void PlayHorn()
    {
        if(!audioSource.isPlaying && wheelBeingHeld && active)
        {
            audioSource.Play();

            if(active)
                GameManager.onGameEvent(GameEvents.CAR_HORN);

        }
    }
}
