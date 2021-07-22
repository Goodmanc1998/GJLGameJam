using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{

    public Vector2 offset;

    public GameObject theCanvas;

    public Sprite handOpen;
    public Sprite handClose;

    public RectTransform canvasRect;


    void Start()
    {
        canvasRect = theCanvas.transform.GetComponent<RectTransform>();
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponent<Image>().sprite = handClose;
        }
        if(Input.GetMouseButtonUp(0))
        {
            this.GetComponent<Image>().sprite = handOpen;
        }
    }

    private void LateUpdate()
    {

        //handRect.position = new Vector2(Input.mousePosition.x - canvasRect.sizeDelta.x / 2f + (offset.x), Input.mousePosition.y - canvasRect.sizeDelta.y / 2f + (offset.y));
        Vector2 objPos = new Vector2();

        objPos.x = Mathf.Clamp(Input.mousePosition.x, -canvasRect.rect.width, canvasRect.rect.width);
        objPos.y = Mathf.Clamp(Input.mousePosition.y, -canvasRect.rect.height, canvasRect.rect.height);
        
        transform.position = objPos;

        
    }
   
}
