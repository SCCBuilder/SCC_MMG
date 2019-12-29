using System.Collections;
using UnityEngine;

public class MMG_Turorial : MonoBehaviour
{

    public GameObject[] popUpArray = new GameObject[5];
    //public int nextGame;

    //bools are false by default
    public bool game0Win, game1Win, game2Win, game3Win, game4Win;

    [HideInInspector]
    private bool game0Start, game1Start, game2Start, game3Start, game4Start;

    // Start is called before the first frame update
    void Start()
    {
        GameStarter(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (game0Start)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) ||
                Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                //Debug.Log("input gotten");
                game0Win = true;
            }
        }

        if (game1Start)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                game1Win = true;
            }
        }

        if (game2Start)
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                game2Win = true;
            }
        }

        //the method game3 handles its own winning
        //And game 4 is un-loseable.
        //Should the tutorial have a timelimit. Seems wrong.
        //Well at least I have the code for the part that has a timelimit.

    }

    public void GameStarter(int gameToStart)
    {
        //getting the first image in the array.
        GameObject imageToDisplay = (GameObject)popUpArray.GetValue(gameToStart);
        //Debug.Log("firstPopUp");
        //starting the animation + activating in the image. When the image activates its child (text) activates.
        //which calls the childs Start methods. Meaning no need to call TypeText in AnimatedText
        imageToDisplay.SetActive(true);

        switch (gameToStart)
        {
            
            case 0:
                //starting game1 with its duration.
                Debug.Log("in switch case. starting game 0");
                StartCoroutine(Game0(5.0f));
                break;
            case 1:
                Debug.Log("in switch case. starting game 1");
                StartCoroutine(Game1(5.0f));
                break;
            case 2:
                Debug.Log("in switch case. starting game 2");
                StartCoroutine(Game2(5.0f));
                break;
            case 3:
                Debug.Log("in switch case. starting game 3");
                StartCoroutine(Game3(5.0f));
                break;
            default:
                Debug.Log("Default case in Switch");
                break;

        }
        
    }

    public IEnumerator Game0(float duration)
    {
        game0Start = true;
        Debug.Log("Started game 0");
        yield return new WaitForSeconds(duration);
        game0Start = false;
        if (game0Win)
        {   //Debug.Log("Won game 0")
            GameStarter(1);
        }
        else
        {
            //Debug.Log("Lost game 0");
            GameEndState.gameEndStateInstance.GameFailed();
        }
    }

    public IEnumerator Game1(float duration)
    {
        game1Start = true;
        Debug.Log("Started game 1");
        yield return new WaitForSeconds(duration);
        game1Start = false;
        Debug.Log("game 1 has finished");
        if (game1Win)
        {
            Debug.Log("Won game 1");
            GameStarter(2);
        }
        else
        {
            Debug.Log("Lost game 1");
            GameEndState.gameEndStateInstance.GameFailed();
        }
    }

    public IEnumerator Game2(float duration)
    {
        game2Start = true;
        Debug.Log("Started game 2");
        yield return new WaitForSeconds(duration);
        game2Start = false;
        Debug.Log("game 2 has finished");
        if (game2Win)
        {
            Debug.Log("Won game 2");
            GameStarter(3);
        }
        else
        {
            Debug.Log("Lost game 2");
            GameEndState.gameEndStateInstance.GameFailed();
        }

    }

    public IEnumerator Game3(float duration)
    {
        game3Start = true;
        Debug.Log("Started game 3");
        int grGemsStart = GameController.gameControllerInstance.grGems;

        yield return new WaitForSeconds(duration);
        game3Start = false;
        Debug.Log("game 3 has finished");
        if (grGemsStart != GameController.gameControllerInstance.grGems)
        {
            Debug.Log("Won game 3");
            GameStarter(4);
        }
        else
        {
            Debug.Log("Lost game 3");
            GameEndState.gameEndStateInstance.GameFailed();
        }        

    }
}
