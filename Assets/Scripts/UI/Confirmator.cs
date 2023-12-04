using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confirmator : MonoBehaviour
{
    public GameObject Father;
    public ObjectPuzzle OP;
    public Inventory I;
    public string Item;

    private void Start() 
    {
        I = FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupConfirmation(ObjectPuzzle Op, string itemToUse)
    {
        OP = Op;
        if(Op.QuitItem)
        {
            Item = itemToUse;
        }
        Father.SetActive(true);
    }

    public void ConfirmUse()
    { 
        Father.SetActive(false);
        OP.Manipulator.Manipulate();
        if(OP.QuitItem)
        {
            I.TakeOutItem(Item);
        }
        OP.AlreadyDecide = true;
    }

    public void CancelUse()
    {
        Father.SetActive(false);
        OP.AlreadyDecide = true;
    }
}