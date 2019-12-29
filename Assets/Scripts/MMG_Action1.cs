using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMG_Action1 : MonoBehaviour
{
    public GameObject[] popUpArray = new GameObject[5];
    //public int nextGame;

    //bools are false by default
    public bool game0Win, game1Win, game2Win, game3Win, game4Win;

    [HideInInspector]
    private bool game0Start, game1Start, game2Start, game3Start, game4Start;
    private bool wasHarmed;
    //private int deafEnemiesStart;

    // Start is called before the first frame update
    void Start()
    {
        GameStarter(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (game1Start)
        {
            wasHarmed = PlayerVariables.playerVariablesInstance.harmed;
        }
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
            case 4:
                Debug.Log("in switch case. starting game 4");
                StartCoroutine(Game4(8.0f));
                break;
            default:
                Debug.Log("Default case in Switch");
                break;

        }

    }

    public IEnumerator Game0(float duration)
    {
        game0Start = true;

        //cant call the GameController in the first frame (which this is)
        //GameController.gameControllerInstance.reachTest();

        yield return new WaitForSeconds(duration);
        game0Start = false;

        if (0 != GameController.gameControllerInstance.deafeatedEnemies)
        {
            game0Win = true;
            GameStarter(1);
            //no need for an else case as game0Win is false by default.
            //well it would handle losing. aka call a method that handles losing.
        }
        else
        {
            Debug.Log("Lost game 0");
            GameEndState.gameEndStateInstance.GameFailed();
        }
    }

    public IEnumerator Game1(float duration)
    {
        game1Start = true;
        //so that the player wont lose for being hit before
        PlayerVariables.playerVariablesInstance.harmed = false;

        yield return new WaitForSeconds(duration);
        game1Start = false;

        if (!wasHarmed)
        {
            game1Win = true;
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

        int grGemsStart = GameController.gameControllerInstance.grGems;

        yield return new WaitForSeconds(duration);
        game2Start = false;

        if (grGemsStart != GameController.gameControllerInstance.grGems)
        {
            game2Win = true;
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

        int grGemsStart = GameController.gameControllerInstance.grGems;

        yield return new WaitForSeconds(duration);
        game3Start = false;

        if (grGemsStart != GameController.gameControllerInstance.grGems)
        {
            game3Win = true;
            GameStarter(4);
        }
        else
        {
            Debug.Log("Lost game 3");
            GameEndState.gameEndStateInstance.GameFailed();
        }
    }

    public IEnumerator Game4(float duration)
    {
        game4Start = true;

        int grGemsStart = GameController.gameControllerInstance.grGems;

        yield return new WaitForSeconds(duration);
        game4Start = false;

        //to show that they have phased, the player has to grab at least 4 gems. 
        if (grGemsStart + 4.0f <= GameController.gameControllerInstance.grGems)
        {
            game4Win = true;
            Debug.Log("won game 4");
            //call a finsihed handler thingy.
            GameEndState.gameEndStateInstance.GameWon();
        }
        else
        {
            Debug.Log("Lost game 4");
            GameEndState.gameEndStateInstance.GameFailed();
        }
    }
}
