using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashSequence : MonoBehaviour
{
    Color32 normalColor;
    public Color32 flashColor;

    public bool on = false;
    // Start is called before the first frame update
    void Start()
    {
        normalColor = this.GetComponent<TextMeshProUGUI>().color;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(on)
        {
            this.GetComponent<TextMeshProUGUI>().color = flashColor;
        }
        else
        {
            this.GetComponent<TextMeshProUGUI>().color = normalColor;
        }
    }
}
