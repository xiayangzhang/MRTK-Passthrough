using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MainMenu;

    public List<GameObject> SubMenu;
    public GameObject lastMenu;
    public HandConstraintPalmUp _handConstraint;
    
    public Handedness currentHand;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuEnabled()
    {
        currentHand = _handConstraint.Handedness;
        MainMenu.SetActive(true);
        if (lastMenu)
        {
            lastMenu.SetActive(true);
        }
        else
        {
            SubMenu[0].SetActive(true);
        }
    }
    
    
    public void disableAllMenu()
    {
        MainMenu.SetActive(false);
        foreach (var menus in SubMenu)
        {
            menus.SetActive(false);
        }
        
    }

    public void SubMenutrigger(GameObject menu)
    {
        
        menu.SetActive(!menu.activeSelf);
    }
}
