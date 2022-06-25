using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCircle : MonoBehaviour
{
    [Header("回転の中心オブジェクト"), SerializeField] GameObject _Target;
    [Header("回転の角度"), SerializeField] float _angle;

    void Update()
    {
        //RotateAround(中心の場所,軸,回転角度) _Targetを中心に回転
        transform.RotateAround(_Target.transform.position, Vector3.up, 360 / _angle * Time.deltaTime);
    }
}