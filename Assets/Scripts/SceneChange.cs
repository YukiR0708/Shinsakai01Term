using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    AudioSource _audioSource;

    [Header("ゲーム終了時のSE")]
    [SerializeField] AudioClip _exitSE;

    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void LoadGameScene() //ゲームシーンへ移動
    {
        SceneManager.LoadScene("MainGame");

    }

    public void LoadTitle() //タイトルへ移動
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void GameEnd()   //ゲーム終了
    {
        _audioSource.PlayOneShot(_exitSE);  //終了時のSE鳴らしてから
        Invoke(nameof(GameQuit), 1.0f);   //ゲームを終了する
    }

    void GameQuit()
    {
        Application.Quit();
    }

}