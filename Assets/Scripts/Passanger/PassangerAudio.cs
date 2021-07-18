using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassangerAudio : MonoBehaviour
{
    public AudioClip[] DowntownMale;
    public AudioClip[] DowntownFemale;

    public AudioClip[] ResidentialMale;
    public AudioClip[] ResidentialFemale;

    public AudioClip[] BankMale;
    public AudioClip[] BankFemale;

    public AudioClip[] GymMale;
    public AudioClip[] GymFemale;

    private static PassangerAudio _instance;
    public static PassangerAudio Instance
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
    }

    public AudioClip GetDestinationAudio(bool male, Location.locationArea destination)
    {
        AudioClip nClip = null;

        if(male)
        {
            if(destination == Location.locationArea.Bank)
            {
                int rndNo = Random.Range(0, BankMale.Length);

                nClip = BankMale[rndNo];
            }

            if (destination == Location.locationArea.Downtown)
            {
                int rndNo = Random.Range(0, DowntownMale.Length);

                nClip = DowntownMale[rndNo];
            }

            if (destination == Location.locationArea.Gym)
            {
                int rndNo = Random.Range(0, GymMale.Length);

                nClip = GymMale[rndNo];
            }

            if (destination == Location.locationArea.Residential)
            {
                int rndNo = Random.Range(0, ResidentialMale.Length);

                nClip = ResidentialMale[rndNo];
            }
        }
        else
        {
            if (destination == Location.locationArea.Bank)
            {
                int rndNo = Random.Range(0, BankFemale.Length);

                nClip = BankMale[rndNo];
            }

            if (destination == Location.locationArea.Downtown)
            {
                int rndNo = Random.Range(0, DowntownFemale.Length);

                nClip = DowntownMale[rndNo];
            }

            if (destination == Location.locationArea.Gym)
            {
                int rndNo = Random.Range(0, GymFemale.Length);

                nClip = GymMale[rndNo];
            }

            if (destination == Location.locationArea.Residential)
            {
                int rndNo = Random.Range(0, ResidentialFemale.Length);

                nClip = ResidentialMale[rndNo];
            }

        }

        return nClip;

    }


}
