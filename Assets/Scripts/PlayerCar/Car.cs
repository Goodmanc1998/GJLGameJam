using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public CarController Controller;
    public NavigationArrow navigation;

    public AudioClip doorOpening, doorClosing, seatbelt;
    AudioSource audioSource;


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

        GameManager.onGameEvent += GettingInCar;

    }

    private void OnDisable()
    {
        GameManager.onGameEvent -= GettingInCar;
    }

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
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

    void GettingInCar(GameEvents currEvent)
    {
        
        if (currEvent == GameEvents.ENTERING_CAR)
        {
            AudioClip[] clipArray = new AudioClip[] { doorOpening, doorClosing, seatbelt };
            StartCoroutine(PlaySoundArray(clipArray));
        }
        else if(currEvent == GameEvents.PASSANGER_DROPPED_OFF)
        {
            AudioClip[] clipArray = new AudioClip[] { seatbelt, doorOpening, doorClosing};
            StartCoroutine(PlaySoundArray(clipArray));
        }




    }

    IEnumerator PlaySoundArray(AudioClip[] clips)
    {
        foreach (AudioClip clip in clips)
        {
            audioSource.clip = clip;

            audioSource.Play();

            yield return new WaitForSeconds(clip.length);
        }
    }


}
