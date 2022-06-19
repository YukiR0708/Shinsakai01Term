using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public static DestroyOutOfBounds instance;
    [Header("¶‚ÌŒÀŠE"), SerializeField] float leftLimit;
    [Header("‰E‚ÌŒÀŠE"), SerializeField] float rightLimit;
    [Header("è‘O‚ÌŒÀŠE"), SerializeField] float bottomLimit;
    [Header("‰œ‚ÌŒÀŠE"), SerializeField] float topLimit;
    float field = -2.618224f;


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
