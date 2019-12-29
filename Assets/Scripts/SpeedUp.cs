using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public float boost;
    public float duration;

    private bool active = true;

    private int counter = 0;
    public List<Color> colors; //list of colors, can be changed in inspector
    //remember to have the colors be at 255 transparency so that they are visible. (or at least not 0)
    SpriteRenderer renderReference;

    void Start()
    {
        //manages colors
        renderReference = GetComponent<SpriteRenderer>();
        renderReference.color = colors[counter];
    }

    public IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && active == true)
        {
            active = false;

            //the values are handled by the mehtod SpeedManager in PlatformInputs
            other.GetComponent<PlatformInputs>().SpeedManager(true, boost);

            //Debug.Log("value of speed in PlatformInputs" + other.GetComponent<PlatformInputs>().speed);
            ChangeColor();
            yield return new WaitForSeconds(duration);

            other.GetComponent<PlatformInputs>().SpeedManager(false, boost);
            active = true;
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        //Debug.Log("color changed");
        //if (coll.other.tag == "Wall") { //uncomment to check tag of colliding object
        if (counter < colors.Count - 1)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }
        renderReference.color = colors[counter];
        //} //uncomment to check tag of colliding object
    }

}
