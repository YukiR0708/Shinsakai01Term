using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボールがスタックした時用のボタン
/// </summary>
/// 

public class BallStacked : MonoBehaviour
{
    [Header("ボールプレハブ(奇数）"), SerializeField] GameObject _ballObj1;
    [Header("ボールプレハブ(偶数）"), SerializeField] GameObject _ballObj2;
    [Header("リスポーンマネージャー"), SerializeField] GameObject _respawnManager;

    public void ButtonPushed()  //ボタンが押されたら
    {
        if (_ballObj1 != null)
        {
            Destroy(_ballObj1);  //ボールを消す
        }

        if (_ballObj2 != null)
        {
            Destroy(_ballObj2);  //ボールを消す
        }

        _respawnManager.GetComponent<RespawnManager>().Respawn();   //リスポーンマネージャーのRespawnメソッドを呼ぶ
    }

}