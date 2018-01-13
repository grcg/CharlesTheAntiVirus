using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartScript : MonoBehaviour {
    public AudioSource restartSound;
    //Replay the game
    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("1Level");
        this.restartSound.Play();
    }
    //Go back to main menu
    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("0Start");
    }
}
