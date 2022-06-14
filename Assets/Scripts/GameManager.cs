using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{

    GameObject _rulePanel;
    GameObject _movChaser1;
    NavMeshAgent _movChaser1_agent;
    GameObject _movChaser2;
    NavMeshAgent _movChaser2_agent;


    void Start()
    {
        _rulePanel = GameObject.Find("RulePanel");
        _movChaser1 = GameObject.Find("MovPlayerChaser1");
        _movChaser1_agent = _movChaser1.GetComponent<NavMeshAgent>();
        _movChaser2 = GameObject.Find("MovPlayerChaser2");
        _movChaser2_agent = _movChaser2.GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        //���[���p�l������A�N�e�B�u�Ȃ�
        if (!_rulePanel.activeSelf)
        {
            _movChaser1_agent.enabled = true;   //MovPlayerChaser1���{�[����ǂ�
            _movChaser2_agent.enabled = true;   //MovPlayerChaser2���{�[����ǂ�
        }
        //���[���p�l�����A�N�e�B�u�Ȃ�
        else
        {
            _movChaser1_agent.enabled = false;   //MovPlayerChaser1���{�[����ǂ�Ȃ�
            _movChaser2_agent.enabled = false;   //MovPlayerChaser2���{�[����ǂ�Ȃ�
        }
    }
}






