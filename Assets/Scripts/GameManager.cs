using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    [Header("ルールパネル"), SerializeField] GameObject _rulePanel;
    [Header("MovPlayerChaser1"), SerializeField] GameObject _movChaser1;
    NavMeshAgent _movChaser1_agent;
    [Header("MovPlayerChaser2"), SerializeField] GameObject _movChaser2;
    NavMeshAgent _movChaser2_agent;
    [Tooltip("トータル制限時間")] float _totalTime;
    [Header("制限時間（分）"), SerializeField] int _minute;
    [Header("制限時間（秒）"), SerializeField] float _seconds;
    [Tooltip("前回Update時の秒数")] float _oldSeconds;
    Text _timerText;
    AudioSource _audioSource;
    [Header("引き分けホイッスルSE"), SerializeField] AudioClip _drawSE;
//    [Tooltip("ゲーム中かどうか")] bool isGame;


    void Start()
    {
        _movChaser1_agent = _movChaser1.GetComponent<NavMeshAgent>();
        _movChaser2_agent = _movChaser2.GetComponent<NavMeshAgent>();
        _totalTime = _minute * 60 + _seconds;
        _oldSeconds = 0f;
        _timerText = GameObject.Find("LeftTime").GetComponent<Text>();
        _audioSource = gameObject.AddComponent<AudioSource>();
 //       isGame = false;
    }


    void Update()
    {
        //ルールパネルが非アクティブなら
        if (!_rulePanel.activeSelf)
        {
            _movChaser1_agent.enabled = true;   //MovPlayerChaser1がボールを追う
            _movChaser2_agent.enabled = true;   //MovPlayerChaser2がボールを追う


            _totalTime = _minute * 60 + _seconds;  //　一旦インスペクターから受け取ったトータルの制限時間（秒）を計算；

            if (_totalTime > 0f)
            {
                _totalTime -= Time.deltaTime;   //カウントダウンする
            }

            if (_totalTime <= 0f) //残り時間が0以下のとき
            {
                _movChaser1_agent.enabled = false;   //MovPlayerChaser1がボールを追わない
                _movChaser2_agent.enabled = false;   //MovPlayerChaser2がボールを追わない
            }


            if (_oldSeconds >= 0f && _totalTime < 0f)   //前のUpdateの残り時間が0以上かつ　今回のUpdateの残り時間が0未満のときだけ
            {
                _audioSource.PlayOneShot(_drawSE, 0.3f);    //ホイッスルを鳴らす
                //Debug.Log("SEが1回鳴った");
                Invoke(nameof(Draw), 2.0f); //引き分けシーン呼び出し
            }


            _minute = (int)_totalTime / 60;   //　再設定
            _seconds = _totalTime - _minute * 60;



            if ((int)_seconds != (int)_oldSeconds)    //　タイマー表示用UIテキストに残り時間を表示する
            {
                _timerText.text = "制限時間：" + _minute.ToString("0") + "分" + ((int)_seconds).ToString("00") + "秒";
            }

            _oldSeconds = _seconds;
        }

        else  if(_rulePanel.activeSelf)//ルールパネルがアクティブなら
        {
            _movChaser1_agent.enabled = false;   //MovPlayerChaser1がボールを追わない
            _movChaser2_agent.enabled = false;   //MovPlayerChaser2がボールを追わない
        }

    }

    void Draw()
    {
        SceneManager.LoadScene("DrawScene");
    }
}
