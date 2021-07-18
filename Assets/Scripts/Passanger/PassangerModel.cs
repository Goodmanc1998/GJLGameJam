using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassangerModel : MonoBehaviour
{
    public GameObject[] maleCharacters;
    public GameObject[] femaleCharacters;

    public bool male;


    // Start is called before the first frame update
    void Start()
    {
        PickModel();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 player = new Vector3(Car.Instance.transform.position.x, transform.position.y, Car.Instance.transform.position.z);

        transform.LookAt(player);
    }

    void PickModel()
    {
        int decider = Mathf.RoundToInt(Random.Range(0, 2));

        if (decider == 0)
        {
            male = false;

            int i = Random.Range(0, maleCharacters.Length);
            maleCharacters[i].SetActive(true);

        }
        else
        {
            male = true;

            int i = Random.Range(0, femaleCharacters.Length);
            femaleCharacters[i].SetActive(true);
        }
    }
}
