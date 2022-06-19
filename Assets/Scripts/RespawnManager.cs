using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    AudioSource _audioSound;

    [Header("ボールのプレハブ")]
    [SerializeField] GameObject _ballPrefabs;

    [Header("ボール出現時のSE")]
    [SerializeField] AudioClip _respawnSound;
    GameObject _rulePanel;

    void Start()
    {
        _audioSound = gameObject.GetComponent<AudioSource>();
        _rulePanel = GameObject.Find("RulePanel");
    }

    void FixedUpdate()
    {
        GameObject ballObj = GameObject.Find("SoccerBall"); //サッカーボールを探す
        if (ballObj == null && !_rulePanel.activeSelf)  //サッカーボールがなくてルールパネルが非表示のとき
        {
            Respawn();
        }
    }

    public void Respawn()   //リスポーンする
    {
        GameObject newBall = Instantiate(_ballPrefabs); //ボールプレハブを生成する
        newBall.name = _ballPrefabs.name;   //オブジェクト名にcloneをつけないようにする
        _audioSound.PlayOneShot(_respawnSound); //ボールスポーン時のSEを鳴らす
    }
}

