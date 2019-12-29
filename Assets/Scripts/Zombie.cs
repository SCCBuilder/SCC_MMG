using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
	public float speed;
	public Transform frontcheck;
	public LayerMask layerMask;

	private float facingRight = -1.0f;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(new Vector3(facingRight, 0f, 0f) * speed * Time.deltaTime);

        if (Physics2D.OverlapPoint(frontcheck.position, layerMask))
        {
            facingRight *= -1.0f;
            transform.localScale = new Vector3(transform.localScale.y * -facingRight, transform.localScale.y,
                transform.localScale.z);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerVariables>().Harm();
        }
    }

    public void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, 13f), ForceMode2D.Impulse);
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        GameController.gameControllerInstance.deafeatedEnemies++;
        Invoke("DisableObject", 3.0f);
    }

    private void DisableObject()
    {
        Destroy(gameObject);
    }

}
