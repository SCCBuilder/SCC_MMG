using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailState : MonoBehaviour
{
    public static FailState failStateInstance;
    public GameObject failDisplay;
    //the target is the player. so the message always appears on screen.
    public Transform target;

    // Start is called before the first frame update
    public void Start()
    {
        failStateInstance = this;
    }

    public void GameFailed()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y + 2.0f, transform.position.z);
        failDisplay.transform.position = targetPosition;
        Debug.Log("in FailState's gamefailed method");
        failDisplay.SetActive(true);
        StartCoroutine(HubLoader());
    }

    public IEnumerator HubLoader()
    {
        Debug.Log("in FailState's hubloader method");
        //short wait so the player cna read the message
        yield return new WaitForSeconds(3);
        //then load the hub
        GameController.gameControllerInstance.LoadLevel(1);
        //Hub is currently level 1. (and will hopefully stay there).
    }
}
