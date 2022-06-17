using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{

    AudioSource _audioSource;

    [Header("蹴った時のSE")]
    [SerializeField] AudioClip _kickedSE;

    [Header("跳ね返り速度の最小値")]
    [SerializeField] float _bounceMin;

    [Header("跳ね返り速度の最大値")]
    [SerializeField] float _bounceMax;

    float _bounce;

    void Start()
    {
        _bounce = Random.Range(_bounceMin, _bounceMax);    //跳ね返り速度をランダムにする
        _audioSource = gameObject.GetComponent<AudioSource>();
    }



    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            other.rigidbody.AddForce(0f, _bounce / 10, _bounce, ForceMode.Impulse);    //ボールを跳ね返す
            _audioSource.PlayOneShot(_kickedSE); //蹴ったときのSEを鳴らす
        }
    }

}

