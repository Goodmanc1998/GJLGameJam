using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashScript : MonoBehaviour
{
    public List<TextMeshProUGUI> text = new List<TextMeshProUGUI>();

    public float timeBetween = 1f;
    public float timer;

    public int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        print(text[0]);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer>=timeBetween)
        {
            if(currentIndex==0)
            {
                text[text.Count-1].GetComponent<FlashSequence>().on = false;
                text[currentIndex].GetComponent<FlashSequence>().on = true;
            }
            else
            {
                text[currentIndex - 1].GetComponent<FlashSequence>().on = false;
                text[currentIndex].GetComponent<FlashSequence>().on = true;
            }

            currentIndex++;
            if (currentIndex >= text.Count) { currentIndex = 0; }

            
            timer = 0;
        }
    }
}
