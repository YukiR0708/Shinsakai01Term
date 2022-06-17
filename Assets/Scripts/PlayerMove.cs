using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [Header("�v���C���[�̈ړ����x")]
    [SerializeField] float _speed;

    Rigidbody _rb;

    private Animator _animator;


    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

    }



    void Update()
    {
        var velox = _speed * 100 * Input.GetAxisRaw("Horizontal");    //velox�ɑ��x�~���E�̖��L�[�̓���
        _rb.AddForce(new Vector3(velox, 0f, 0f));   //���������ɍ��E�ړ�

        if (_animator != null)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _animator.SetBool("BoBump", true);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                _animator.SetBool("BoBump", false);
            }
        }
    }

}


