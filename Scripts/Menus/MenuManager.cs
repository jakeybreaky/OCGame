using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Signal openMenu;
    public Signal closeMenu;
    public GameObject menu;
    public bool IsOpen { get; private set; }

    private void Start()
    {
        IsOpen = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Menu") && IsOpen == false)
        {
            OpenMenu();
        }

        if (Input.GetButtonDown("Menu") && IsOpen == true)
        {
            CloseMenu();
        }
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
        openMenu.Raise();
        IsOpen = true;
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        closeMenu.Raise();
        IsOpen = false;
    }


}
