using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovChaserController : MonoBehaviour
{
    NavMeshAgent _agent;
    GameObject _ball;
    GameObject _goal;

    void Start()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();

    }
    void Update()
    {
        _ball = GameObject.FindGameObjectWithTag("Ball");
        _goal = GameObject.Find("backGoal");

        if (_agent.enabled && _ball != null) //追跡モブがアクティブでボールがあるとき
        {
            _agent.destination = _ball.transform.position;   //ボールを追いかける
        }
        else if (_agent.enabled && _ball == null) //追跡モブがアクティブでボールがないとき
        {
            _agent.destination = _goal.transform.position;  //ゴールに向かう
        }
    }
}