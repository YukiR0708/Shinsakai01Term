using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    AudioSource _audioSound;

    [Header("中央のボールプレハブ")]
    [SerializeField] GameObject _ballPrefabs;

    [Header("ゴール前のボールプレハブ")]
    [SerializeField] GameObject _ballPrefabs2;


    [Header("ボール出現時のSE")]
    [SerializeField] AudioClip _respawnSound;
    GameObject _rulePanel;

    [Tooltip("ボールのスポーン回数")]
    int count;

    void Start()
    {
        _audioSound = gameObject.GetComponent<AudioSource>();
        _rulePanel = GameObject.Find("RulePanel");
        count = 0;
    }

    void FixedUpdate()
    {
        GameObject ballObj = GameObject.FindWithTag("Ball"); //サッカーボールを探す
        if (ballObj == null && !_rulePanel.activeSelf)  //サッカーボールがなくてルールパネルが非表示のとき
        {
            Respawn();
        }
    }

    public void Respawn()   //リスポーンする
    {
        count++;
        if (count % 2 != 0)
        {
            GameObject newBall = Instantiate(_ballPrefabs); //中央にボールプレハブを生成する
            newBall.name = _ballPrefabs.name;   //オブジェクト名にcloneをつけないようにする
        }   else
        {
            GameObject newBall = Instantiate(_ballPrefabs2); //ゴール前にボールプレハブを生成する
            newBall.name = _ballPrefabs2.name;   //オブジェクト名にcloneをつけないようにする

        }


        _audioSound.PlayOneShot(_respawnSound); //ボールスポーン時のSEを鳴らす

    }
}

