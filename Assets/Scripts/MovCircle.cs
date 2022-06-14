using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCircle : MonoBehaviour
{
    [SerializeField] GameObject _Target;
    [SerializeField] float _angle;

    void Update()
    {
        //RotateAround(���S�̏ꏊ,��,��]�p�x) _Target�𒆐S�ɉ�]
        transform.RotateAround(_Target.transform.position, Vector3.up, 360 / _angle * Time.deltaTime);
    }
}