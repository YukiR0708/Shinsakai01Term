using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BackGoalScore : MonoBehaviour
{
    AudioSource _audioSource;

    [Header("青スコア時のSE"), SerializeField] AudioClip _blueScoreSE;

    [Header("敗北条件点数"), SerializeField] int _forLoseScore;

    int _blueScore;
    Text _textScore;

    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _blueScore = 0;
        _textScore = GameObject.Find("BlueScore").GetComponent<Text>();

        SetScoreText(_blueScore);
    }

    void SetScoreText(int blueScore)
    {
        _textScore.text = blueScore.ToString();
    }

    void AddScoreText()
    {
        _blueScore++;   //スコア加算

        if (_blueScore < _forLoseScore)
        {
            SetScoreText(_blueScore);   //スコア表示
        }
        else if (_blueScore == _forLoseScore)   //_forLoseScore点になったら
        {
            SetScoreText(_blueScore);   //スコア表示
            SceneManager.LoadScene("LoseScene");    //敗北シーンへ移動
        }
    }


    void OnTriggerEnter(Collider other)  //ボールがゴール内の透明パネルに当たったら
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Destroy(other); //ボールを消す
            Invoke(nameof(AddScore), 0.5f);
        }
    }

    void AddScore()
    {
        _audioSource.PlayOneShot(_blueScoreSE);  //青スコア時のSEを鳴らす
        AddScoreText(); //スコアを加算する
    }
}