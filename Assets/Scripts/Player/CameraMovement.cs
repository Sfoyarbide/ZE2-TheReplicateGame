using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    public bool CanMove;

    // Update is called once per frame
    void Update()
    {
        if(CanMove)
        {
            float x = Input.GetAxisRaw("Horizontal");
            Movement(x);
        }
    }

    void Movement(float x)
    {
        if(x == -1)
        {
            this.transform.Rotate(0, -speed * Time.deltaTime, 0);
        }
        else if(x == 1)
        {
            this.transform.Rotate(0, speed * Time.deltaTime, 0);
        }
    }
}