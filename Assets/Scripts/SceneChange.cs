using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    AudioSource _audioSource;

    [Header("�Q�[���I������SE")]
    [SerializeField] AudioClip _exitSE;

    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void LoadGameScene() //�Q�[���V�[���ֈړ�
    {
        FadeManager.Instance.LoadScene("MainGame", 1.0f);

    }

    public void LoadTitle() //�^�C�g���ֈړ�
    {
        FadeManager.Instance.LoadScene("TitleScene", 1.0f);
    }

    public void GameEnd()   //�Q�[���I��
    {
        _audioSource.PlayOneShot(_exitSE);  //�I������SE�炵�Ă���
        Invoke(nameof(GameQuit), 1.0f);   //�Q�[�����I������
    }

    void GameQuit()
    {
        Application.Quit();
    }

}