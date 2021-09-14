using System.Collections;
using System.Collections.Generic;using Oculus.Platform.Models;
using UnityEngine;

/*public class Room
{
    public List<wall> walls;
    public Vector3 RoomPos;
    
}*/
public class HomeEditor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialog;
    public Room RoomPrefab;
    public List<Room> rooms;
    public Room CurrentRoom;

    public float defaultFloorOffest;
    public float defaultCeilingOffest;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EditRoom()
    {
        if (!isInroom() )
        {
            Room newRoom = Instantiate(RoomPrefab,transform);
            rooms.Add(newRoom);
            //newRoom.setUp();
        }
    }

    bool isInroom()
    {
        return false;
    }

    public void showDialog()
    {
        dialog.SetActive(true);
    }
}
