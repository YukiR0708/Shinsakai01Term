using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [Header("�v���C���[�̈ړ����x"), SerializeField] float _speed;

    Rigidbody _rb;

    private Animator _animator;


    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }



    void Update()
    {
        var velox = _speed * Time.deltaTime * Input.GetAxisRaw("Horizontal");    //velox�ɑ��x�~���E�̖��L�[�̓���

        _rb.AddForce(velox * 10000, 0f, 0f);   //���������ɍ��E�ړ�

        if (_animator != null)  //null�`�F�b�N
        {
            if (Input.GetKeyDown(KeyCode.Space))    //�X�y�[�X�������ꂽ��
            {
                _animator.SetTrigger("TrBump");
            }

            if (Input.GetKeyUp(KeyCode.Space))  //�X�y�[�X�������ꂽ��
            {
                _animator.SetTrigger("TrBumped");
            }
        }
    }

}


