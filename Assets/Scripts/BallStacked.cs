using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �{�[�����X�^�b�N�������p�̃{�^��
/// </summary>
/// 

public class BallStacked : MonoBehaviour
{
    GameObject _ballObj;
    GameObject _respawnManager;

    public void ButtonPushed()  //�{�^���������ꂽ��
    {
        _ballObj = GameObject.Find("SoccerBall");   //�{�[����T��
        _respawnManager = GameObject.Find("RespawnManager");
        Destroy(_ballObj);  //�{�[��������
        _respawnManager.GetComponent<RespawnManager>().Respawn();   //���X�|�[���}�l�[�W���[��Respawn���\�b�h���Ă�
    }

}