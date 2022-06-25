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
    [SerializeField] GameObject _respawnManager;

    public void ButtonPushed()  //�{�^���������ꂽ��
    {
        _ballObj = GameObject.FindGameObjectWithTag("Ball");

        if (_ballObj != null)
        {
            Destroy(_ballObj);  //�{�[��������
        }


        _respawnManager.GetComponent<RespawnManager>().Respawn();   //���X�|�[���}�l�[�W���[��Respawn���\�b�h���Ă�
    }

}