using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManipulateObject : MonoBehaviour
{
    public bool ChangePosition, ChangeScene, AddItem;
    public string SceneToChange, ItemToAdd;
    public GameObject ObjectPuzzle;
    public Inventory I;
    public Vector3 PosOb;
    public Vector3 RotOb;

    private void Start() 
    {
        I = FindObjectOfType<Inventory>();
    }

    public void Manipulate()
    {
        if(ChangeScene)
        {
            SceneManager.LoadScene(SceneToChange);
        }
        if(ChangePosition)
        {
            ObjectPuzzle.transform.position = PosOb;
            ObjectPuzzle.transform.localRotation = Quaternion.Euler(RotOb);
        }
        if(AddItem)
        {
            I.addItem(ItemToAdd);
            //Destroy(this.gameObject);
        }
    }
}
