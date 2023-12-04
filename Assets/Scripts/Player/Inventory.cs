using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Text ItemGrabbedText, NewItemGrabbedText;
    public List<string> items;
    public int index = 0;

    private void Update() 
    {
        MoveInTheIndex();
        UpdateUi();
    }

    void MoveInTheIndex()
    {
        if(Input.GetKeyDown(KeyCode.Q) && index != 0)
        {
            index--;
        }
        if(Input.GetKeyDown(KeyCode.E) && index != items.Count-1)
        {
            index++;
        }
    }

    void UpdateUi()
    {
        ItemGrabbedText.text = items[index];
    }

    public void addItem(string item)
    {
        items.Add(item);
        StartCoroutine(addItemEffect(item));
    }

    public void TakeOutItem(string item)
    {
        index = 0;
        items.Remove(item);
        StartCoroutine(TakeOutItemEffect(item));
    }

    IEnumerator addItemEffect(string item)
    {
        NewItemGrabbedText.text = item + "+";
        yield return new WaitForSecondsRealtime(2.0f);
        NewItemGrabbedText.text = "";
    }

    IEnumerator TakeOutItemEffect(string item)
    {
        NewItemGrabbedText.text = item + "-";
        yield return new WaitForSecondsRealtime(2.0f);
        NewItemGrabbedText.text = "";
    }

    public void ButtonIzq()
    {
        if(index != 0)
        {
            index--;
        }
    }

    public void ButtonDer()
    {
        if(index != items.Count-1)
        {
            index++;
        }
    }
}