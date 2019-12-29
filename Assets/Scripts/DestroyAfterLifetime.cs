using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterLifetime : MonoBehaviour
{

    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", lifeTime);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
