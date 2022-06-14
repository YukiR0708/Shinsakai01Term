using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [Header("�v���C���[�̈ړ����x")]
    [SerializeField] float _speed;

    Rigidbody _rb;

    [Header("�W�����v��")]
    [SerializeField] float _upForce;

    bool isOnGround = false;

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        var velox = _speed * 100 * Input.GetAxisRaw("Horizontal") * Time.deltaTime;    //velox�ɑ��x�~���E�̖��L�[�̓���

        if (isOnGround)
        {
            _rb.AddForce(new Vector3(velox, 0f, 0f));   //���������ɍ��E�ړ�
        }

        if (Input.GetKeyDown("space") && isOnGround)    //�X�y�[�X�L�[������ ���� �n�ʂɒ����Ă����灨��i�W�����v�h�~
        {
            Jump(); //�W�����v����
            isOnGround = false;
        }
    }

    void Jump()
    {
        _rb.AddForce(new Vector3(0f, _upForce * 100 * Time.deltaTime, 0f));
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))  //���n����
        {
            isOnGround = true;

        }
        else if (collision.gameObject.CompareTag("Ball"))    //�{�[���ɓ���������y���}�C�i�X��AddForce����
        {                                                       //�{�[���ɏ�����Ƃ���ɔ�΂���Ȃ���
            _rb.AddForce(new Vector3(0f, -100f, 0f));
        }
    }
}


