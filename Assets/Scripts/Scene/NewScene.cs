using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewScene : MonoBehaviour
{
    public bool button = false;
    public string newScene;

    Button btn;

    private void Start()
    {
        if(button)
            GetButton();
    }

    void GetButton()
    {
        btn = gameObject.GetComponent<Button>();

        btn.onClick.AddListener(ChangeScene);
    }

    public void ChangeScene()
    {
        SceneController.Instance.UpdateScene(newScene);
    }

    
    


}
