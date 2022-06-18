using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKeeperMove : MonoBehaviour
{
    [Header("キーパーの移動速度"), SerializeField] float _speed;
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
            _rb.AddForce(new Vector3(-veloxLeft, 0f, 0f));  //左シフトキーで左へ移動
        }
        else if (Input.GetKey(KeyCode.RightShift))
        {
            var veloxRight = _speed;
            _rb.AddForce(new Vector3(veloxRight, 0f, 0f));  //右シフトキーで右へ移動
        }
    }
}
