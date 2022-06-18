using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKeeperMove : MonoBehaviour
{
    [Header("�L�[�p�[�̈ړ����x"), SerializeField] float _speed;
    Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            var veloxLeft = _speed;
            _rb.AddForce(new Vector3(-veloxLeft, 0f, 0f));  //���V�t�g�L�[�ō��ֈړ�
        }
        else if (Input.GetKey(KeyCode.RightShift))
        {
            var veloxRight = _speed;
            _rb.AddForce(new Vector3(veloxRight, 0f, 0f));  //�E�V�t�g�L�[�ŉE�ֈړ�
        }
    }
}
