using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRollBar : MonoBehaviour
{

    public WheelCollider fl, fr;
    public float AntiRoll;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.centerOfMass = new Vector3(0, -0.5f, 0);
    }

    private void FixedUpdate()
    {
        WheelHit hit = new WheelHit();

        float travelL = 1.0f;
        float travelR = 1.0f;

        bool groundedL = fl.GetGroundHit(out hit);

        if(groundedL)
        {
            travelL = (-fl.transform.InverseTransformPoint(hit.point).y - fl.radius / fl.suspensionDistance);
        }

        bool groundedR = fl.GetGroundHit(out hit);

        if (groundedR)
        {
            travelR = (-fr.transform.InverseTransformPoint(hit.point).y - fr.radius / fr.suspensionDistance);
        }

        var antiRollForce = (travelL - travelR) * AntiRoll;

        if (groundedL)
            rb.AddForceAtPosition(fl.transform.up * -antiRollForce, fl.transform.position);

        if (groundedR)
            rb.AddForceAtPosition(fr.transform.up * -antiRollForce, fr.transform.position);

    }
}
