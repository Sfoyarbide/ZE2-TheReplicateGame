using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public bool TheEnd;
    public GameObject theEnd, _I;
    public GameObject SeekAWayOut;
    public GameObject button;
    public GameObject[] Card;
    public bool YouCanAdvance;

    public int index = 0;

    private void Update() 
    {
        if(YouCanAdvance && Input.GetMouseButtonDown(0) && !TheEnd)
        {
            SceneManager.LoadScene("Room1");
        }
        if(YouCanAdvance && Input.GetMouseButtonDown(0) && TheEnd)
        {
            StartCoroutine(EndTheGame());
        }
    }

    public void passToNextOne()
    {
        if(index != Card.Length-1 && !TheEnd)
        {
            Card[index].SetActive(false);
            index++;
            Card[index].SetActive(true);
        }
        else 
        {
            StartCoroutine(StartTheGame());
        }
    }

    IEnumerator StartTheGame()
    {
        button.GetComponent<Button>().enabled = false;
        if(!TheEnd)
        {
            Card[1].SetActive(false);
        }
        else{ Card[0].SetActive(false); }
        yield return new WaitForSecondsRealtime(0.9f);
        button.SetActive(false);
        yield return new WaitForSecondsRealtime(2f); 
        SeekAWayOut.SetActive(true);
        YouCanAdvance = true;
    }

    IEnumerator EndTheGame()
    {
        SeekAWayOut.SetActive(false);
        yield return new WaitForSecondsRealtime(2.5f);
        theEnd.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        _I.SetActive(true);
        yield return new WaitForSecondsRealtime(3.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
