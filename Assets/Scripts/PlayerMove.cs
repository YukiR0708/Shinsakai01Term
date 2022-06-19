using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [Header("プレイヤーの移動速度"), SerializeField] float _speed;

    Rigidbody _rb;

    private Animator _animator;


    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }



    void Update()
    {
        var velox = _speed * Time.deltaTime * Input.GetAxisRaw("Horizontal");    //veloxに速度×左右の矢印キーの入力

        _rb.AddForce(velox * 10000, 0f, 0f);   //ｘ軸方向に左右移動

        if (_animator != null)  //nullチェック
        {
            if (Input.GetKeyDown(KeyCode.Space))    //スペースが押されたら
            {
                _animator.SetTrigger("TrBump");
            }

            if (Input.GetKeyUp(KeyCode.Space))  //スペースが離されたら
            {
                _animator.SetTrigger("TrBumped");
            }
        }
    }

}


