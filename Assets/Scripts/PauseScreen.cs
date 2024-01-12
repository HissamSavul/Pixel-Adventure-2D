using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{    
    [SerializeField] private GameObject ourPlayer;
    public void SetupPause(){
        ourPlayer.SetActive(false);
        gameObject.SetActive(true);
    }
    public void ResumeGame(){
        ourPlayer.SetActive(true);
        gameObject.SetActive(false);
    }
    public void RestartButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitButton(){
        SceneManager.LoadScene(0);
    }
}
