using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [Header("プレイヤーの移動速度")]
    [SerializeField] float _speed;

    Rigidbody _rb;

    [Header("ジャンプ力")]
    [SerializeField] float _upForce;

    bool isOnGround = false;

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        var velox = _speed * 100 * Input.GetAxisRaw("Horizontal") * Time.deltaTime;    //veloxに速度×左右の矢印キーの入力

        if (isOnGround)
        {
            _rb.AddForce(new Vector3(velox, 0f, 0f));   //ｘ軸方向に左右移動
        }

        if (Input.GetKeyDown("space") && isOnGround)    //スペースキーを押す かつ 地面に着いていたら→二段ジャンプ防止
        {
            Jump(); //ジャンプする
            isOnGround = false;
        }
    }

    void Jump()
    {
        _rb.AddForce(new Vector3(0f, _upForce * 100 * Time.deltaTime, 0f));
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))  //着地判定
        {
            isOnGround = true;

        }
        else if (collision.gameObject.CompareTag("Ball"))    //ボールに当たった時y軸マイナスにAddForceする
        {                                                       //ボールに乗ったとき上に飛ばされない為
            _rb.AddForce(new Vector3(0f, -100f, 0f));
        }
    }
}


