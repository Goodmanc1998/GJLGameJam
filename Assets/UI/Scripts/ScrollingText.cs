using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollingText : MonoBehaviour
{
    public TextMeshProUGUI textMeshProObj;
    public float scrollSpeed = 5f;

    private TextMeshProUGUI cloneTextObj;

    private RectTransform textRect;

    // Start is called before the first frame update
    void Awake()
    {
        textRect = textMeshProObj.GetComponent<RectTransform>();

        cloneTextObj = Instantiate(textMeshProObj) as TextMeshProUGUI;
        RectTransform cloneRect = cloneTextObj.GetComponent<RectTransform>();
        cloneRect.SetParent(textRect);
        cloneRect.anchorMin = new Vector2(1f, 0.5f);
        cloneRect.localScale = new Vector3(1, 1, 1);
        cloneRect.anchoredPosition = Vector3.zero;
    }

    IEnumerator Start()
    {
        float width = textMeshProObj.preferredWidth;
        Vector3 startPos = textRect.position;

        float scrollPos = 0;

        while(true)
        {
            if(textMeshProObj.transform.hasChanged)
            {
                width = textMeshProObj.preferredWidth;
                cloneTextObj.text = textMeshProObj.text;
            }

            textRect.position = new Vector3(-scrollPos % width, startPos.y, startPos.z);

            scrollPos += scrollSpeed * Time.deltaTime *10;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
