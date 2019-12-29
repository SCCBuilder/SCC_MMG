using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text gemText;

    public void Start()
    {
        gemText.text = "Gems: " + PlayerPrefs.GetInt("gems");
    }

    public void StartGame()
    {
        //the game starts with thte tutorial level.
        PlayerPrefs.SetInt("gems", 0);
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
