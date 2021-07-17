using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnginePitch : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip engineSound;

    public float minPitch = 0.05f;
    public float maxPitch = 2f;

    public float carSpeed;

    public float topSpeed;

    public float idlePitch = 1f;

    CarController car;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = minPitch;
        audioSource.clip = engineSound;
        car = this.GetComponent<CarController>();

        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0.7f;
        audioSource.loop = true;
        audioSource.Play();
    }


    void Update()
    {
        carSpeed = car.velocity;
        audioSource.pitch = carSpeed <= 3 ? idlePitch : carSpeed*5 / topSpeed;
    }
}
