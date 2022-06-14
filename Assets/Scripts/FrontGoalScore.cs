using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FrontGoalScore : MonoBehaviour
{
    AudioSource _audioSource;

    [Header("赤スコア時のSE")]
    [SerializeField] AudioClip _redScoreSE;

    int _redScore;
    Text _textScore;

    void Start()
    {
        _redScore = 0;
        _audioSource = gameObject.GetComponent<AudioSource>();
        _textScore = GameObject.Find("RedScore").GetComponent<Text>();

        SetScoreText(_redScore);
    }

    void SetScoreText(int redScore)
    {
        _textScore.text = redScore.ToString();
    }

    void AddScoreText()
    {
        _redScore++;    //スコア加算

        if (_redScore < 5)
        {
            SetScoreText(_redScore);    //スコア表示

        }
        else if (_redScore == 5)    //５点になったら
        {
            SetScoreText(_redScore);    //スコア表示
            SceneManager.LoadScene("WinScene");     //勝利シーンへ移動
        }
    }

    void OnTriggerEnter(Collider other)     //ボールがゴール内の透明パネルにすり抜けたら
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other); //ボールを消す            
            AddScoreText(); //スコアを加算する
            _audioSource.PlayOneShot(_redScoreSE);  //SEを鳴らす
        }
    }
}