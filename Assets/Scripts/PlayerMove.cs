using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [Header("プレイヤーの移動速度")]
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
        var velox = _speed * 100 * Input.GetAxisRaw("Horizontal");    //veloxに速度×左右の矢印キーの入力
        _rb.AddForce(new Vector3(velox, 0f, 0f));   //ｘ軸方向に左右移動

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


