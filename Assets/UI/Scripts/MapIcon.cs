using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapIcon : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI theText;
    public RectTransform rectTransform;
    public RectTransform iconRectTransform;

    public void SetIcon(Sprite icon) => image.sprite = icon;
    public void SetColor(Color color) => image.color = color;
    public void SetText(string text)
    {
        if(!string.IsNullOrEmpty(text))
        {
            theText.enabled = true;
            theText.text = text;
        }
    }
    public void SetTextSize(int size) => theText.fontSize = size;
}
