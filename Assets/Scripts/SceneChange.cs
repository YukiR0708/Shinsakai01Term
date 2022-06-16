using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    AudioSource _audioSource;

    [Header("�Q�[���I������SE")]
    [SerializeField] AudioClip _exitSE;

    [Header("�t�F�[�h�p�C���[�W")]
    [SerializeField] Image _fadeImage;

    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }


    public void StartFadeOut(string scene)//�t�F�[�h�A�E�g�֐�
    {
        _fadeImage.gameObject.SetActive(true);
        this._fadeImage.DOFade(duration: 1f, endValue: 1f).OnComplete(() => SceneManager.LoadScene(scene));
        //Image��Color�͓����ɐݒ�
    }
    public void StartFadeIn()//�t�F�[�h�C���֐�
    {
        this._fadeImage.DOFade(endValue: 0f, duration: 1f).OnComplete(() => _fadeImage.gameObject.SetActive(false));
        //Image��Color�͐^�����ɐݒ�
    }
    public void Fade(bool type, string scene)//�Ăяo���֐�
    {
        if (type)
        {
            this._fadeImage.DOFade(endValue: 0f, duration: 1f).OnComplete(() => _fadeImage.gameObject.SetActive(false));
            //Image��Color�͐^�����ɐݒ�
        }
        else
        {
            _fadeImage.gameObject.SetActive(true);
            this._fadeImage.DOFade(duration: 1f, endValue: 1f).OnComplete(() => SceneManager.LoadScene(scene));
            //Image��Color�͓����ɐݒ�
        }
    }



    //public void LoadGameScene(string scene) //�Q�[���V�[���ֈړ�
    //{
    //    SceneManager.LoadScene("MainGame");

    //}

    //public void LoadTitle() //�^�C�g���ֈړ�
    //{
    //    SceneManager.LoadScene("TitleScene");
    //}



    public void GameEnd()   //�Q�[���I��
    {
        _audioSource.PlayOneShot(_exitSE);  //�I������SE�炵�Ă���
        Invoke(nameof(GameQuit), 1.0f);   //1�b��ɃQ�[�����I������
    }

    void GameQuit()
    {
        Application.Quit();
    }

}