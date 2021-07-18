using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map instance = null;

    public GameObject theMapObj;

    [SerializeField]
    RectTransform scrollViewRectTransform;

    [SerializeField]
    RectTransform contentRectTransform;

    [SerializeField]
    MapIcon mapIconPrefab;
    Dictionary<MapWorldObj, MapIcon> mapWorldObjLookup = new Dictionary<MapWorldObj, MapIcon>();

    public Vector2 offset;

    public Vector2 scaleRatio;

    public void RegisterMapWorldObj(MapWorldObj mapObj)
    {
        var mapIcon = Instantiate(mapIconPrefab);
        mapIcon.transform.SetParent(contentRectTransform);
        mapIcon.SetIcon(mapObj.icon);
        mapIcon.SetColor(mapObj.iconColor);
        mapIcon.SetText(mapObj.theText);
        mapIcon.SetTextSize(mapObj.textSize);
        mapWorldObjLookup[mapObj] = mapIcon;

        print("ran");
    }
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CalculateTransformationMatrix();
    }

    void CalculateTransformationMatrix()
    {
        var miniMapDimentions = contentRectTransform.rect.size;
        var mapDimentions = new Vector2(theMapObj.GetComponent<Collider>().bounds.size.x, theMapObj.GetComponent<Collider>().bounds.size.z);

        scaleRatio = miniMapDimentions / mapDimentions;
       
    }

    void UpdateMapIcons()
    {
        foreach(var thing in mapWorldObjLookup)
        {
            var miniMapWorldObj = thing.Key;
            var miniMapIcon = thing.Value;

            var mapPos = WorldPosToMapPos(miniMapWorldObj.transform.position);

            miniMapIcon.rectTransform.anchoredPosition = mapPos;

            var rotation = miniMapWorldObj.transform.rotation.eulerAngles;
            miniMapIcon.iconRectTransform.localRotation = Quaternion.AngleAxis(-rotation.y, Vector3.forward);
        }
    }

    Vector2 WorldPosToMapPos(Vector3 worldPos)
    {
        var pos = new Vector2(worldPos.z, -worldPos.x) + offset;

        return pos * scaleRatio;

    }
    // Update is called once per frame
    void Update()
    {
        UpdateMapIcons();
    }
}
