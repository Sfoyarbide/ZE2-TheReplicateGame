using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Animator[] anims;
    public string sceneToChange;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Menu());
    }

    IEnumerator Menu()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        anims[0].SetBool("LogoCan", true);
        yield return new WaitForSecondsRealtime(3f);
        anims[1].SetBool("LogoCan", true);
    }

    public void StartTheGame()
    {
        SceneManager.LoadScene(sceneToChange);
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
