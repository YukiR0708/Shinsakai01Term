using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovChaserController : MonoBehaviour
{
    NavMeshAgent _agent;
    GameObject _ball;
    [Header("Player"), SerializeField] GameObject _player;

    void Start()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();

    }
    void Update()
    {
        _ball = GameObject.FindGameObjectWithTag("Ball");

        if (_agent.enabled && _ball != null) //�ǐՃ��u���A�N�e�B�u�Ń{�[��������Ƃ�
        {
            _agent.destination = _ball.transform.position;   //�{�[����ǂ�������
        }
        else if (_agent.enabled && _ball == null) //�ǐՃ��u���A�N�e�B�u�Ń{�[�����Ȃ��Ƃ�
        {
            _agent.destination = _player.transform.position;  //�v���C���[�Ɍ�����
        }
    }
}