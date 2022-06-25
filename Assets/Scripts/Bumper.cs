using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{

    AudioSource _audioSource;

    [Header("�R��������SE"), SerializeField] AudioClip _kickedSE;

    [Header("���˕Ԃ葬�x�̍ŏ��l"), SerializeField] float _bounceMin;

    [Header("���˕Ԃ葬�x�̍ő�l"), SerializeField] float _bounceMax;

    public float _bounce;

    void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
    }



    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball" && _kickedSE !=�@null)
        {
            _bounce = Random.Range(_bounceMin, _bounceMax) * Time.deltaTime * 50;    //���˕Ԃ葬�x�������_���ɂ���
//            Debug.Log($"���˕Ԃ葬�x��{_bounce}");
            other.rigidbody.AddForce(0f, _bounce/10, _bounce, ForceMode.Impulse);    //�{�[���𒵂˕Ԃ�
            _audioSource.PlayOneShot(_kickedSE, 0.3f); //�R�����Ƃ���SE��炷
        }
    }

}

