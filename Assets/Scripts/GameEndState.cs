using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndState : MonoBehaviour
{
    public static GameEndState gameEndStateInstance;
    public GameObject winDisplay;
    public GameObject failDisplay;
    //the target is the player. so the message always appears on screen.
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        gameEndStateInstance = this;
    }

    public void GameWon()
    {
        Debug.Log("in GameEndState's GameWon method");

        Vector3 targetPosition = new Vector3(target.position.x, target.position.y + 2.0f, transform.position.z);
        winDisplay.transform.position = targetPosition;
        winDisplay.SetActive(true);
        StartCoroutine(HubLoader());
    }


    public void GameFailed()
    {
        Debug.Log("in GameEndState's GameFailed method");
        GameController.gameControllerInstance.grGems = 0;

        Vector3 targetPosition = new Vector3(target.position.x, target.position.y + 2.0f, transform.position.z);
        failDisplay.transform.position = targetPosition;
        failDisplay.SetActive(true);
        StartCoroutine(HubLoader());
    }

    public IEnumerator HubLoader()
    {
        Debug.Log("in GameEndState's HubLoader method");
        //short wait so the player cna read the message
        yield return new WaitForSeconds(3);
        //then load the hub
        GameController.gameControllerInstance.LoadLevel(1);
        //Hub is currently level 1. (and will hopefully stay there).
    }
}
