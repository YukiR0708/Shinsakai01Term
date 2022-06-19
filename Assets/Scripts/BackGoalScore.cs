using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BackGoalScore : MonoBehaviour
{
    AudioSource _audioSource;

    [Header("�X�R�A����SE"), SerializeField] AudioClip _blueScoreSE;

    [Header("�s�k�����_��"), SerializeField] int _forLoseScore;

    int _blueScore;
    Text _textScore;

    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _blueScore = 0;
        _textScore = GameObject.Find("BlueScore").GetComponent<Text>();

        SetScoreText(_blueScore);
    }

    void SetScoreText(int blueScore)
    {
        _textScore.text = blueScore.ToString();
    }

    void AddScoreText()
    {
        _blueScore++;   //�X�R�A���Z

        if (_blueScore < _forLoseScore)
        {
            SetScoreText(_blueScore);   //�X�R�A�\��
        }
        else if (_blueScore == _forLoseScore)   //_forLoseScore�_�ɂȂ�����
        {
            SetScoreText(_blueScore);   //�X�R�A�\��
            SceneManager.LoadScene("LoseScene");    //�s�k�V�[���ֈړ�
        }
    }


    void OnTriggerEnter(Collider other)  //�{�[�����S�[�����̓����p�l���ɓ���������
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Destroy(other); //�{�[��������
            Invoke(nameof(AddScore), 0.5f);
        }
    }

    void AddScore()
    {
        _audioSource.PlayOneShot(_blueScoreSE);  //�X�R�A����SE��炷
        AddScoreText(); //�X�R�A�����Z����
    }
}