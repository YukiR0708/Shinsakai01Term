using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BackGoalScore : MonoBehaviour
{
    AudioSource _audioSource;

    [Header("青スコア時のSE")]
    [SerializeField] AudioClip _blueScoreSE;

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

        if (_blueScore < 5)
        {
            SetScoreText(_blueScore);   //スコア表示
        }
        else if (_blueScore == 5)   //5点になったら
        {
            SetScoreText(_blueScore);   //スコア表示
            SceneManager.LoadScene("LoseScene");    //敗北シーンへ移動
        }
    }


    void OnTriggerEnter(Collider other)     //ボールがゴール内の透明パネルにすり抜けたら
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other); //ボールを消す
            AddScoreText(); //スコアを加算する
            _audioSource.PlayOneShot(_blueScoreSE);  //青スコア時のSEを鳴らす
        }
    }
}