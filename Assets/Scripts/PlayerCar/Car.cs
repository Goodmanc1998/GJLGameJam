using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public CarController Controller;
    public NavigationArrow navigation;
    public SteeringWheel steeringWheel;

    public AudioClip doorOpening, doorClosing, seatbelt;
    public AudioSource audioSource;


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

    }

    private void Update()
    {

        
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
            AudioClip[] clipArray = new AudioClip[] { doorOpening, doorClosing, seatbelt, PassangerAudio.Instance.GetDestinationAudio(currPassanger.GetComponentInChildren<PassangerModel>().male, currPassanger.GetFinishingLocation().GetLocationArea()) };
            StartCoroutine(PlaySoundArray(clipArray));
        }
        else if (currEvent == GameEvents.PASSANGER_DROPPED_OFF)
        {
            AudioClip[] clipArray = new AudioClip[] { seatbelt, doorOpening, doorClosing };
            StartCoroutine(PlaySoundArray(clipArray));
        }
        else if (currEvent == GameEvents.GAME_OVER)
            steeringWheel.active = false;

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
