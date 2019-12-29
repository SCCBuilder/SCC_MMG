using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController gameControllerInstance;
    public Text grGemText;

    [HideInInspector]
    public int grGems;
    public int deafeatedEnemies;

    // Start is called before the first frame update
    public void Start()
    {
        //Debug.Log("reached start in Gamecontroller");
        gameControllerInstance = this;
        grGems = 0;
        deafeatedEnemies = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        grGemText.text = grGems.ToString();
    }

    

    public void LoadLevel(int levelToLoad)
    {
        int previousGems = PlayerPrefs.GetInt("gems");
        Debug.Log("previous gems " + previousGems);
        previousGems += grGems;
        PlayerPrefs.SetInt("gems", previousGems);
        Debug.Log("gems after adding" + previousGems);

        SceneManager.LoadScene(levelToLoad);
        Debug.Log("level to load " + levelToLoad);
    }
}
