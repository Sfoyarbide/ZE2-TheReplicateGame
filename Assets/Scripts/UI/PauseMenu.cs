using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public CameraMovement CM;
    public GameObject Father;

    private void Start() 
    {
        CM = FindObjectOfType<CameraMovement>();
    }

    private void Update() 
    {
        OpenMenu();
    }

    public void OpenMenu()
    {
        if(CM.CanMove && Input.GetKeyDown(KeyCode.T))
        {
            Father.SetActive(true);
            CM.CanMove = false;
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Cancel()
    {
        Father.SetActive(false);
        CM.CanMove = true;
    }
}
