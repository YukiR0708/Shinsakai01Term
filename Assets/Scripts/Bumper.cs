using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{

    AudioSource _audioSource;

    [Header("�R��������SE")]
    [SerializeField] AudioClip _kickedSE;

    [Header("���˕Ԃ葬�x�̍ŏ��l")]
    [SerializeField] float _bounceMin;

    [Header("���˕Ԃ葬�x�̍ő�l")]
    [SerializeField] float _bounceMax;

    float _bounce;

    void Start()
    {
        _bounce = Random.Range(_bounceMin, _bounceMax);    //���˕Ԃ葬�x�������_���ɂ���
        _audioSource = gameObject.GetComponent<AudioSource>();
    }



    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            other.rigidbody.AddForce(0f, _bounce / 10, _bounce, ForceMode.Impulse);    //�{�[���𒵂˕Ԃ�
            _audioSource.PlayOneShot(_kickedSE); //�R�����Ƃ���SE��炷
        }
    }

}

