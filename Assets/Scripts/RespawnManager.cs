using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    AudioSource _audioSound;

    [Header("�����̃{�[���v���n�u")]
    [SerializeField] GameObject _ballPrefabs;

    [Header("�S�[���O�̃{�[���v���n�u")]
    [SerializeField] GameObject _ballPrefabs2;


    [Header("�{�[���o������SE")]
    [SerializeField] AudioClip _respawnSound;
    GameObject _rulePanel;

    [Tooltip("�{�[���̃X�|�[����")]
    int count;

    void Start()
    {
        _audioSound = gameObject.GetComponent<AudioSource>();
        _rulePanel = GameObject.Find("RulePanel");
        count = 0;
    }

    void FixedUpdate()
    {
        GameObject ballObj = GameObject.FindWithTag("Ball"); //�T�b�J�[�{�[����T��
        if (ballObj == null && !_rulePanel.activeSelf)  //�T�b�J�[�{�[�����Ȃ��ă��[���p�l������\���̂Ƃ�
        {
            Respawn();
        }
    }

    public void Respawn()   //���X�|�[������
    {
        count++;
        if (count % 2 != 0)
        {
            GameObject newBall = Instantiate(_ballPrefabs); //�����Ƀ{�[���v���n�u�𐶐�����
            newBall.name = _ballPrefabs.name;   //�I�u�W�F�N�g����clone�����Ȃ��悤�ɂ���
        }   else
        {
            GameObject newBall = Instantiate(_ballPrefabs2); //�S�[���O�Ƀ{�[���v���n�u�𐶐�����
            newBall.name = _ballPrefabs2.name;   //�I�u�W�F�N�g����clone�����Ȃ��悤�ɂ���

        }


        _audioSound.PlayOneShot(_respawnSound); //�{�[���X�|�[������SE��炷

    }
}

