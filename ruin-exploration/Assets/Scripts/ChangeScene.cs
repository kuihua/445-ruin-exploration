using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void StartGame() {
        SceneManager.LoadScene("Ruin Game");
    }

    public void GoToStart() {
        SceneManager.LoadScene("StartScreen");
    }

    public void Win() {
        SceneManager.LoadScene("WinScreen");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
