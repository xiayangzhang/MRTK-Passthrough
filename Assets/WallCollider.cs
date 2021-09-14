using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public wall leftWall;
    public wall RightWall;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AutoHeight()
    {
        float height = FindObjectOfType<HomeEditor>().defaultCeilingOffest -
                     FindObjectOfType<HomeEditor>().defaultFloorOffest;
        Vector3 newpos = transform.position;
        newpos.y = FindObjectOfType<HomeEditor>().defaultFloorOffest+height/2;
        transform.position = newpos;
        transform.localScale = new Vector3(100, height, 0.01f);
    }

    /*
    private void OnCollisionStay(Collision other)
    {
        Debug.Log(other.contactCount);
    }
    */

   
}
