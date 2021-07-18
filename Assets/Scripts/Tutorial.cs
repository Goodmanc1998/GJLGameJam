using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public GameObject menuObject;
    public GameObject tutorialObject;

    bool menu = true;


    // Start is called before the first frame update
    void Start()
    {
        tutorialObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        menu = !menu;

        if(menu)
        {
            menuObject.SetActive(true);
            tutorialObject.SetActive(false);
        }
        else
        {
            menuObject.SetActive(false);
            tutorialObject.SetActive(true);
        }
    }
}
