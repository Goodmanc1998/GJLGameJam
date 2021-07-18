using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PassangerAudio : MonoBehaviour
{

    [System.Serializable]
    public struct AudioLocation
    {
        public AudioClip[] male;
        public AudioClip[] female;
    }

    public AudioLocation Downtown;
    public AudioLocation Residential;
    public AudioLocation OldTown;
    public AudioLocation Office;
    public AudioLocation Bank;
    public AudioLocation Gym;
    public AudioLocation CoffeShop;
    public AudioLocation BarberShop;
    public AudioLocation Club;
    public AudioLocation BigMall;
    public AudioLocation MidTown;
    public AudioLocation NorthPark;
    public AudioLocation SouthPark;
    public AudioLocation Cinema;
    public AudioLocation WaterFront;

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


        if (destination == Location.locationArea.Downtown)
        {
            if (male)
            {
                int rndNo = Random.Range(0, Downtown.male.Length);

                nClip = Downtown.male[rndNo];
            }
            else
            {
                int rndNo = Random.Range(0, Downtown.female.Length);

                nClip = Downtown.female[rndNo];
            }

        }
        else if (destination == Location.locationArea.Residential)
        {
            if (male)
            {
                int rndNo = Random.Range(0, Residential.male.Length);

                nClip = Residential.male[rndNo];
            }
            else
            {
                int rndNo = Random.Range(0, Residential.female.Length);

                nClip = Downtown.female[rndNo];
            }
        }
        else if (destination == Location.locationArea.OldTown)
        {
            if (male)
            {
                int rndNo = Random.Range(0, OldTown.male.Length);

                nClip = OldTown.male[rndNo];
            }
            else
            {
                int rndNo = Random.Range(0, OldTown.female.Length);

                nClip = OldTown.female[rndNo];
            }
        }
        else if (destination == Location.locationArea.Office)
        {
            if (male)
            {
                int rndNo = Random.Range(0, Office.male.Length);

                nClip = Office.male[rndNo];
            }
            else
            {
                int rndNo = Random.Range(0, Office.female.Length);

                nClip = Office.female[rndNo];
            }
        }
        else if (destination == Location.locationArea.Bank)
        {
            if (male)
            {
                int rndNo = Random.Range(0, Bank.male.Length);

                nClip = Bank.male[rndNo];
            }
            else
            {
                int rndNo = Random.Range(0, Bank.female.Length);

                nClip = Bank.female[rndNo];
            }
        }
        else if (destination == Location.locationArea.Gym)
        {
            if (male)
            {
                int rndNo = Random.Range(0, Gym.male.Length);

                nClip = Gym.male[rndNo];
            }
            else
            {
                int rndNo = Random.Range(0, Gym.female.Length);

                nClip = Gym.female[rndNo];
            }
        }
        else if (destination == Location.locationArea.CoffeeShop)
        {
            if(male)
            {
                int rndNo = Random.Range(0, CoffeShop.male.Length);

                nClip = CoffeShop.male[rndNo];
            }
            else
            {
                int rndNo = Random.Range(0, CoffeShop.female.Length);

                nClip = CoffeShop.female[rndNo];
            }
        }
        else if (destination == Location.locationArea.BarberShop)
        {
            if (male)
            {
                int rndNo = Random.Range(0, BarberShop.male.Length);

                nClip = BarberShop.male[rndNo];
            }
            else
            {
                int rndNo = Random.Range(0, BarberShop.female.Length);

                nClip = BarberShop.female[rndNo];
            }
        }
        else if (destination == Location.locationArea.Club)
        {
            if (male)
            {
                int rndNo = Random.Range(0, Club.male.Length);

                nClip = Club.male[rndNo];
            }
            else
            {
                int rndNo = Random.Range(0, Club.female.Length);

                nClip = Club.female[rndNo];
            }
        }
        else if (destination == Location.locationArea.BigMall)
        {
            if (male)
            {
                int rndNo = Random.Range(0, BigMall.male.Length);

                nClip = BigMall.male[rndNo];
            }
            else
            {
                int rndNo = Random.Range(0, BigMall.female.Length);

                nClip = BigMall.female[rndNo];
            }
        }
        else if (destination == Location.locationArea.MidTown)
        {
            if (male)
            {
                int rndNo = Random.Range(0, MidTown.male.Length);

                nClip = MidTown.male[rndNo];
            }
            else
            {
                int rndNo = Random.Range(0, MidTown.female.Length);

                nClip = MidTown.female[rndNo];
            }
        }
        else if (destination == Location.locationArea.NorthPark)
        {
            if (male)
            {
                int rndNo = Random.Range(0, NorthPark.male.Length);

                nClip = NorthPark.male[rndNo];
            }
            else
            {
                int rndNo = Random.Range(0, NorthPark.female.Length);

                nClip = NorthPark.female[rndNo];
            }
        }
        else if (destination == Location.locationArea.SouthPark)
        {
            if (male)
            {
                int rndNo = Random.Range(0, SouthPark.male.Length);

                nClip = SouthPark.male[rndNo];
            }
            else
            {
                int rndNo = Random.Range(0, SouthPark.female.Length);

                nClip = SouthPark.female[rndNo];
            }
        }
        else if (destination == Location.locationArea.Cinema)
        {
            if (male)
            {
                int rndNo = Random.Range(0, Cinema.male.Length);

                nClip = Cinema.male[rndNo];
            }
            else
            {
                int rndNo = Random.Range(0, Cinema.female.Length);

                nClip = Cinema.female[rndNo];
            }
        }
        else if (destination == Location.locationArea.WaterFront)
        {
            if (male)
            {
                int rndNo = Random.Range(0, WaterFront.male.Length);

                nClip = WaterFront.male[rndNo];
            }
            else
            {
                int rndNo = Random.Range(0, WaterFront.female.Length);

                nClip = WaterFront.female[rndNo];
            }
        }

        return nClip;

    }


}
