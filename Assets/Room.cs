using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    // Start is called before the first frame update
    public List<wall> walls =new List<wall>();
    private Vector3 roomPos;
    private HomeEditor _homeEditor;

    public wall wallPrefab;

    public bool WallEditing = false;


    void Start()
    {
        _homeEditor = FindObjectOfType<HomeEditor>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void setUp()
    {
        if (!isValidRoom())
        {
            _homeEditor.showDialog();
           // AddWall();
        }
    }

    public void EditWall()
    {
      
    }
    public void AddWall()
    {
        wall Newwall = Instantiate(wallPrefab, transform);
      //  Newwall.Editing = true;
        walls.Add(Newwall);
    }

    bool isValidRoom()
    {
        return (walls.Count >= 4);

    }

    bool handvalid()
    {
        return true;
    }


}
