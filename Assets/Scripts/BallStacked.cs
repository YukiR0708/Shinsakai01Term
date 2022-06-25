using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボールがスタックした時用のボタン
/// </summary>
/// 

public class BallStacked : MonoBehaviour
{
    GameObject _ballObj;
    [SerializeField] GameObject _respawnManager;

    public void ButtonPushed()  //ボタンが押されたら
    {
        _ballObj = GameObject.FindGameObjectWithTag("Ball");

        if (_ballObj != null)
        {
            Destroy(_ballObj);  //ボールを消す
        }


        _respawnManager.GetComponent<RespawnManager>().Respawn();   //リスポーンマネージャーのRespawnメソッドを呼ぶ
    }

}