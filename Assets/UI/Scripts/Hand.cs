using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{

    public Vector2 offset;

    public GameObject theCanvas;

    public Sprite handOpen;
    public Sprite handClose;

    public RectTransform canvasRect;

    private void Awake()
    {
        GameManager.onGameEvent += Event;

    }

    private void OnDisable()
    {
        GameManager.onGameEvent -= Event;
    }
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

        objPos.x = Input.mousePosition.x + offset.x;
        objPos.y = Input.mousePosition.y + offset.y;

        objPos.y = Mathf.Clamp(objPos.y, 0, Screen.height / 2);

        transform.position = objPos;

        
    }

    void Event(GameEvents currEvent)
    {
        if (currEvent != GameEvents.GAME_OVER)
            return;

        Destroy(this.gameObject);
    }
   
}
