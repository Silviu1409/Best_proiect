using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    private static string PlayScene = "SampleScene";
    public void PlayGame()
    {
        SceneManager.LoadScene(PlayScene);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }



        public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
