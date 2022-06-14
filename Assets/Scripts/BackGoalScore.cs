using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BackGoalScore : MonoBehaviour
{
    AudioSource _audioSource;

    [Header("�X�R�A����SE")]
    [SerializeField] AudioClip _blueScoreSE;

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

        if (_blueScore < 5)
        {
            SetScoreText(_blueScore);   //�X�R�A�\��
        }
        else if (_blueScore == 5)   //5�_�ɂȂ�����
        {
            SetScoreText(_blueScore);   //�X�R�A�\��
            SceneManager.LoadScene("LoseScene");    //�s�k�V�[���ֈړ�
        }
    }


    void OnTriggerEnter(Collider other)     //�{�[�����S�[�����̓����p�l���ɂ��蔲������
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other); //�{�[��������
            AddScoreText(); //�X�R�A�����Z����
            _audioSource.PlayOneShot(_blueScoreSE);  //�X�R�A����SE��炷
        }
    }
}