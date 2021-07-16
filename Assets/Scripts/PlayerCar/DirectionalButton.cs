using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DirectionalButton : MonoBehaviour
{

    float currDir;

    TMP_Text txtField;

    // Start is called before the first frame update
    void Start()
    {
        currDir = -1;
        txtField = gameObject.GetComponentInChildren<TMP_Text>();
        ChangeDir();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (currDir == 1)
        {
            currDir = -1;
            txtField.text = "Reverse";

        }
        else
        {
            currDir = 1;
            txtField.text = "Forward";
        }

        
    }

    public void ChangeDir()
    {
        if (currDir == 1)
        {
            currDir = -1;
            txtField.text = "Reverse";

        }
        else
        {
            currDir = 1;
            txtField.text = "Forward";
        }
    }

    public float GetDirection()
    {
        return currDir;
    }
}
