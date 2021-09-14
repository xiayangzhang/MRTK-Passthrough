using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine;

public class scrollablePanel : MonoBehaviour
{
    public bool submenuEnabled = false;
    // Start is called before the first frame update
    private HandConstraintPalmUp _handConstraintPalm;

    public GameObject mainQuad;
    public GameObject Submenu;

    public Handedness lastHand;
    void Start()
    {
        _handConstraintPalm = GetComponent<HandConstraintPalmUp>();
        init();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void init()
    {
       
            mainQuad.transform.localScale = new Vector3(0.032f*2, 0.032f*4, 0.0106f);
            mainQuad.transform.localPosition =new Vector3(0, 0, 0);
            Submenu.SetActive(false);
        
    }

    /*
    public void submenuclick()
    {
        if (submenuEnabled==true)
        {
            mainQuad.transform.localScale = new Vector3(0.032f*2, 0.032f*4, 0.0106f);
            mainQuad.transform.localPosition =new Vector3(0, 0, 0);
            Submenu.SetActive(false);
        }
        else
        {
            WindowsResize();
        }
        
    }
    */

    public void OpenMenu()
    {
        lastHand = _handConstraintPalm.Handedness;
        init();
        Debug.Log("OpenMenu");
    }
    
    
    public void openSubMenu()
    {
        Submenu.SetActive(true);

        Debug.Log(_handConstraintPalm.Handedness);
        if (lastHand == Handedness.Left)
        {
            mainQuad.transform.localScale = new Vector3(0.032f*5, 0.032f*4, 0.0106f);
            mainQuad.transform.localPosition =new Vector3(0.032f/2*3, 0, 0);

            
            
            Submenu.transform.localPosition = new Vector3(0.032f*2, 0, -1.0104f);
            
            Debug.Log("Open left sub Menu");

        }
        else if(lastHand == Handedness.Right)
        {
            mainQuad.transform.localScale = new Vector3(0.032f*5, 0.032f*4, 0.0106f);
            mainQuad.transform.localPosition =new Vector3(-0.032f/2*3, 0, 0);

            
            Submenu.transform.localPosition = new Vector3(-0.032f*2, 0, -1.0104f);
           
            Debug.Log("Open right sub Menu");

        }
    }
}
