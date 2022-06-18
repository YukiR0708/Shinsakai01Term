using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    GameObject _rulePanel;
    GameObject _movChaser1;
    NavMeshAgent _movChaser1_agent;
    GameObject _movChaser2;
    NavMeshAgent _movChaser2_agent;

    float _totalTime;        //　トータル制限時間
    [Header("制限時間（分）"),SerializeField]  int _minute;

    [Header("制限時間（秒）"),SerializeField]  float _seconds;

    float _oldSeconds;       //　前回Update時の秒数
    Text _timerText;


    void Start()
    {
        _rulePanel = GameObject.Find("RulePanel");
        _movChaser1 = GameObject.Find("MovPlayerChaser1");
        _movChaser1_agent = _movChaser1.GetComponent<NavMeshAgent>();
        _movChaser2 = GameObject.Find("MovPlayerChaser2");
        _movChaser2_agent = _movChaser2.GetComponent<NavMeshAgent>();
        _totalTime = _minute * 60 + _seconds;
        _oldSeconds = 0f;
        _timerText = GameObject.Find("LeftTime").GetComponent<Text>();
    }


    void Update()
    {
        //ルールパネルが非アクティブなら
        if (!_rulePanel.activeSelf)
        {
            _movChaser1_agent.enabled = true;   //MovPlayerChaser1がボールを追う
            _movChaser2_agent.enabled = true;   //MovPlayerChaser2がボールを追う
        }
        //ルールパネルがアクティブなら
        else
        {
            _movChaser1_agent.enabled = false;   //MovPlayerChaser1がボールを追わない
            _movChaser2_agent.enabled = false;   //MovPlayerChaser2がボールを追わない
        }

        
        if (_totalTime <= 0f)    //　制限時間が0秒以下なら引き分けシーンへ移動
        {
            SceneManager.LoadScene("DrawScene");     

        }

        _totalTime = _minute * 60 + _seconds;  //　一旦トータルの制限時間を計測；
        _totalTime -= Time.deltaTime;

        
        _minute = (int)_totalTime / 60;   //　再設定
        _seconds = _totalTime - _minute * 60;

        
        if ((int)_seconds != (int)_oldSeconds)    //　タイマー表示用UIテキストに時間を表示する
        {
            _timerText.text = "制限時間：" + _minute.ToString("0") + "分" + ((int)_seconds).ToString("00") + "秒";
        }


        _oldSeconds = _seconds;
        

        if (_totalTime <= 0f)    //　制限時間以下になったらコンソールに『制限時間終了』という文字列を表示する
        {
            Debug.Log("制限時間終了");
        }
    }
}






