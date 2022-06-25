using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �{�[�����X�^�b�N�������p�̃{�^��
/// </summary>
/// 

public class BallStacked : MonoBehaviour
{
    [Header("�{�[���v���n�u(��j"), SerializeField] GameObject _ballObj1;
    [Header("�{�[���v���n�u(�����j"), SerializeField] GameObject _ballObj2;
    [Header("���X�|�[���}�l�[�W���["), SerializeField] GameObject _respawnManager;

    public void ButtonPushed()  //�{�^���������ꂽ��
    {
        if (_ballObj1 != null)
        {
            Destroy(_ballObj1);  //�{�[��������
        }

        if (_ballObj2 != null)
        {
            Destroy(_ballObj2);  //�{�[��������
        }

        _respawnManager.GetComponent<RespawnManager>().Respawn();   //���X�|�[���}�l�[�W���[��Respawn���\�b�h���Ă�
    }

}