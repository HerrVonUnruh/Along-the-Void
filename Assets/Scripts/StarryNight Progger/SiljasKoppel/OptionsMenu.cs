using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsMenu : MonoBehaviour
{
    public GameObject firstMenuButton;
    public MainMenu menu;

    public bool solle = false;

  
    void Update()
    {
        ChangeScene();
    }

    public void ChangeScene()
    {
        if (solle == true)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstMenuButton);
            solle = false;
            menu.selle = true;

        }
        
    }
}
