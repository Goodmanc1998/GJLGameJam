using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationPointer : MonoBehaviour
{

    public Color desination;
    public Color passanger;
    public Color unActive;

    MeshRenderer meshRenderer;

    ParticleSystem particleEffect;


    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
        meshRenderer.material.color = unActive;

        SetUpParticle();
    }

    void SetUpParticle()
    {
        particleEffect = GetComponentInChildren<ParticleSystem>();
        var shape = particleEffect.shape;
        shape.radius = PassangerManager.Instance.minCarDistance;

        particleEffect.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).GetChild(0).transform.RotateAround(transform.position, transform.up, 1);
    }

    public void UpdateDestination()
    {
        meshRenderer.material.color = desination;

        particleEffect.startColor = desination;
        particleEffect.Play();

    }

    public void UpdatePassanger()
    {
        meshRenderer.material.color = passanger;

        particleEffect.startColor = passanger;
        particleEffect.Play();
    }

    public void UpdateUnActive()
    {
        meshRenderer.material.color = unActive;

        particleEffect.Stop();
    }



}
