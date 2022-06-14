using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public static DestroyOutOfBounds instance;
    private float leftLimit = 0.1f;
    private float rightLimit = 10.5f;
    private float bottomLimit = -19.0f;
    private float topLimit = -0.3f;
    private float field = -2.618224f;
//    public bool judgement;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > rightLimit)
        { 
            Destroy(gameObject);
        }
        else if (transform.position.z < bottomLimit)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z > topLimit)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < field)
        {
            Destroy(gameObject);
        }

    }
}
