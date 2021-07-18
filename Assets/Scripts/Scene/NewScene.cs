using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewScene : MonoBehaviour
{
    public bool button = false;
    public bool quit;
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
    }

    public void ChangeScene()
    {
        if (!quit)
        {
            SceneController.Instance.UpdateScene(newScene);
        }
        else
            SceneController.Instance.QuitApplication();


    }

    
    


}
