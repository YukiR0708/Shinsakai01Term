using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCircle : MonoBehaviour
{
    [SerializeField] GameObject _Target;
    [SerializeField] float _angle;

    void Update()
    {
        //RotateAround(’†S‚ÌêŠ,²,‰ñ“]Šp“x) _Target‚ğ’†S‚É‰ñ“]
        transform.RotateAround(_Target.transform.position, Vector3.up, 360 / _angle * Time.deltaTime);
    }
}