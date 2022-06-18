using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FrontGoalScore : MonoBehaviour
{
    AudioSource _audioSource;

    [Header("�ԃX�R�A����SE"), SerializeField] AudioClip _redScoreSE;

    [Header("���������_��"), SerializeField] int _forWinScore;
    int _redScore;
    Text _textScore;

    void Start()
    {
        _redScore = 0;
        _audioSource = gameObject.GetComponent<AudioSource>();
        _textScore = GameObject.Find("RedScore").GetComponent<Text>();

        SetScoreText(_redScore);
    }

    void SetScoreText(int redScore)
    {
        _textScore.text = redScore.ToString();
    }

    void AddScoreText()
    {
        _redScore++;    //�X�R�A���Z

        if (_redScore < _forWinScore)
        {
            SetScoreText(_redScore);    //�X�R�A�\��

        }
        else if (_redScore == _forWinScore)    //_forWinScore�_�ɂȂ�����
        {
            SetScoreText(_redScore);    //�X�R�A�\��
            SceneManager.LoadScene("WinScene");     //�����V�[���ֈړ�
        }
    }

    void OnTriggerEnter(Collider other)     //�{�[�����S�[�����̓����p�l���ɂ��蔲������
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other); //�{�[��������            
            AddScoreText(); //�X�R�A�����Z����
            _audioSource.PlayOneShot(_redScoreSE);  //SE��炷
        }
    }
}