using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapWorldObj : MonoBehaviour
{
    public Sprite icon;
    public Color iconColor = Color.black;
    public string theText;
    public int textSize = 10;

    // Start is called before the first frame update
    private void Start()
    {
        Map.instance.RegisterMapWorldObj(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
