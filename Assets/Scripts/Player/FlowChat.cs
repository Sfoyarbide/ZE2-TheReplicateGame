using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowChat : MonoBehaviour
{
    public int Room, replicate;
    public bool Showing, NotCanShow;
    CameraMovement CM;
    public GameObject Father;
    public GameObject YouAreHere;
    public GameObject[] Rooms;
    public Image[] replicates;
    public Sprite[] _12345;

    // Start is called before the first frame update
    void Start()
    {
        YouAreHere.transform.position = Rooms[Room].transform.position;
        replicates[Room].sprite = _12345[replicate];
        CM = FindObjectOfType<CameraMovement>();
    }
    
    public void Show()
    {
        if(!NotCanShow)
        {
            Showing = !Showing;
            Father.SetActive(Showing);
            if(Showing)
            {
                CM.CanMove = false;
            }
            else
            {
                CM.CanMove = true;
            }
        }
    }
}
