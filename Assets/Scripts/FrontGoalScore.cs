using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FrontGoalScore : MonoBehaviour
{
    AudioSource _audioSource;

    [Header("赤スコア時のSE"), SerializeField] AudioClip _redScoreSE;

    [Header("勝利条件点数"), SerializeField] int _forWinScore;
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

        if (_redScore < _forWinScore)
        {
            SetScoreText(_redScore);    //スコア表示

        }
        else if (_redScore == _forWinScore)    //_forWinScore点になったら
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