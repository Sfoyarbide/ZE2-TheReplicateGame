using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPuzzle : MonoBehaviour
{
    [Header("PuzzleSettings")]
    public ManipulateObject Manipulator;
    public bool NotUseItem;
    public bool QuitItem;
    public bool NotChangeCamPos;
    public bool AlreadyDecide = true;
    public bool AlreadyDoTheAccion;
    public string Item;
    [Header("Settings")]
    bool CanPosition, AlreadyClick;
    Confirmator Confirmator;
    CameraMovement Camera;
    Inventory Inventory;
    public Vector3 positionCam, rotationCam;
    public Vector3 savePosCam, saveRotCam;
    // Start is called before the first frame update
    void Start()
    {
        Camera = FindObjectOfType<CameraMovement>();
        Inventory = FindObjectOfType<Inventory>();
        Manipulator = GetComponent<ManipulateObject>();
        Confirmator = FindObjectOfType<Confirmator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfReady();
    }

    public void positionCamera()
    {
        Camera.CanMove = false;
        Camera.transform.position = positionCam;
        Camera.transform.localRotation = Quaternion.Euler(rotationCam);
    }

    public void ReturnOriginalPosCamera()
    {
        Camera.transform.position = savePosCam;
        Camera.transform.localRotation = Quaternion.Euler(saveRotCam);
        Camera.CanMove = true;
        AlreadyClick = false;
        CanPosition = false;
    }

    public void CheckIfReady()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && CanPosition && !NotChangeCamPos && AlreadyDecide)
        {
            ReturnOriginalPosCamera();
        }
    }

    private void OnMouseUp() 
    {
        if(NotChangeCamPos)
        {
            AlreadyClick = true;
        }
        if(AlreadyClick)
        {
            if(NotUseItem && !AlreadyDoTheAccion)
            {
                Manipulator.Manipulate();
                AlreadyDoTheAccion = true;
            }
            if(Inventory.items[Inventory.index] == Item || Inventory.items[Inventory.index] == "White Key")
            {
                AlreadyDecide = false;
                Confirmator.SetupConfirmation(this, Item);
                //Inventory.TakeOutItem(Item);
            }
        }
        else if(!AlreadyClick && Camera.CanMove)
        {
            savePosCam = Camera.transform.position;
            saveRotCam = Camera.transform.rotation.eulerAngles;
            if(!NotChangeCamPos)
            {
                positionCamera();
            }
            CanPosition = true;
            AlreadyClick = true;
        }
    }
}
