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
    [Tooltip("�g�[�^����������")] float _totalTime;
    [Header("�������ԁi���j"), SerializeField] int _minute;
    [Header("�������ԁi�b�j"), SerializeField] float _seconds;
    [Tooltip("�O��Update���̕b��")] float _oldSeconds;
    Text _timerText;
    AudioSource _audioSource;
    [Header("���������z�C�b�X��SE"), SerializeField] AudioClip _drawSE;
    //    [Tooltip("�^�C���A�b�v���ǂ���")] bool isTimeUp;


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
        _audioSource = gameObject.AddComponent<AudioSource>();
        //        isTimeUp = false;
    }


    void Update()
    {
        //���[���p�l������A�N�e�B�u�Ȃ�
        if (!_rulePanel.activeSelf)
        {
            _movChaser1_agent.enabled = true;   //MovPlayerChaser1���{�[����ǂ�
            _movChaser2_agent.enabled = true;   //MovPlayerChaser2���{�[����ǂ�


            _totalTime = _minute * 60 + _seconds;  //�@��U�C���X�y�N�^�[����󂯎�����g�[�^���̐������ԁi�b�j���v�Z�G

            if (_totalTime > 0f)
            {
                _totalTime -= Time.deltaTime;   //�J�E���g�_�E������
            }

            if (_oldSeconds >= 0f && _totalTime < 0f)   //�O��Update�̎c�莞�Ԃ�0�ȏォ�@�����Update�̎c�莞�Ԃ�0�����̂Ƃ�����
            {
                _audioSource.PlayOneShot(_drawSE, 0.3f);    //�z�C�b�X����炷
                //Debug.Log("SE��1�����");
                Invoke(nameof(Draw), 2.0f); //���������V�[���Ăяo��
            }

            if(_totalTime <= 0f) //�c�莞�Ԃ�0�ȉ��̂Ƃ�
            {
                _movChaser1_agent.enabled = false;   //MovPlayerChaser1���{�[����ǂ�Ȃ�
                _movChaser2_agent.enabled = false;   //MovPlayerChaser2���{�[����ǂ�Ȃ�
            }

            _minute = (int)_totalTime / 60;   //�@�Đݒ�
            _seconds = _totalTime - _minute * 60;



            if ((int)_seconds != (int)_oldSeconds)    //�@�^�C�}�[�\���pUI�e�L�X�g�Ɏc�莞�Ԃ�\������
            {
                _timerText.text = "�������ԁF" + _minute.ToString("0") + "��" + ((int)_seconds).ToString("00") + "�b";
            }

            _oldSeconds = _seconds;
        }

        else    //���[���p�l�����A�N�e�B�u�Ȃ�
        {
            _movChaser1_agent.enabled = false;   //MovPlayerChaser1���{�[����ǂ�Ȃ�
            _movChaser2_agent.enabled = false;   //MovPlayerChaser2���{�[����ǂ�Ȃ�
        }

    }

    void Draw()
    {
        SceneManager.LoadScene("DrawScene");
    }
}
