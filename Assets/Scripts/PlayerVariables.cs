using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    public Transform startPosition;
    public GameObject gemParticles;
    public AudioClip coinPickUpSound, harmSound;
    public static PlayerVariables playerVariablesInstance;
    //checked at the end of games where the player needs to dodge something.
    public bool harmed;


    private float damageTimer;
    private AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        playerVariablesInstance = this;
    }

    private void Update()
    {
        damageTimer += Time.deltaTime;
    }

    public void Harm()
    {
        if(damageTimer > 1.0f)
        {
            damageTimer = 0;
            Debug.Log("got hit");

            harmed = true;

            GetComponent<Rigidbody2D>().AddForce(new Vector2(-5f, 8f), ForceMode2D.Impulse);
            myAudioSource.PlayOneShot(harmSound);
        }
    }

    public void Respawn()
    {
        transform.position = startPosition.position;
        harmed = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Instantiate(gemParticles, other.transform.position, Quaternion.identity);
            other.gameObject.SetActive(false);
            //Debug.Log("tag is collectible");
            GameController.gameControllerInstance.grGems ++;

            myAudioSource.pitch = Random.Range(0.5f, 1.5f);
            myAudioSource.PlayOneShot(coinPickUpSound);


        }
    }


}
