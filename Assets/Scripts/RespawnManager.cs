using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    AudioSource _audioSound;

    [Header("�{�[���̃v���n�u")]
    [SerializeField] GameObject _ballPrefabs;

    [Header("�{�[���o������SE")]
    [SerializeField] AudioClip _respawnSound;
    GameObject _rulePanel;

    void Start()
    {
        _audioSound = gameObject.GetComponent<AudioSource>();
        _rulePanel = GameObject.Find("RulePanel");
    }

    void FixedUpdate()
    {
        GameObject ballObj = GameObject.Find("SoccerBall"); //�T�b�J�[�{�[����T��
        if (ballObj == null && !_rulePanel.activeSelf)  //�T�b�J�[�{�[�����Ȃ��ă��[���p�l������\���̂Ƃ�
        {
            Respawn();
        }
    }

    public void Respawn()   //���X�|�[������
    {
        GameObject newBall = Instantiate(_ballPrefabs); //�{�[���v���n�u�𐶐�����
        newBall.name = _ballPrefabs.name;   //�I�u�W�F�N�g����clone�����Ȃ��悤�ɂ���
        _audioSound.PlayOneShot(_respawnSound); //�{�[���X�|�[������SE��炷
    }
}

