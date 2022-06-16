using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    AudioSource _audioSource;

    [Header("ゲーム終了時のSE")]
    [SerializeField] AudioClip _exitSE;

    [Header("フェード用イメージ")]
    [SerializeField] Image _fadeImage;

    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }


    public void StartFadeOut(string scene)//フェードアウト関数
    {
        _fadeImage.gameObject.SetActive(true);
        this._fadeImage.DOFade(duration: 1f, endValue: 1f).OnComplete(() => SceneManager.LoadScene(scene));
        //ImageのColorは透明に設定
    }
    public void StartFadeIn()//フェードイン関数
    {
        this._fadeImage.DOFade(endValue: 0f, duration: 1f).OnComplete(() => _fadeImage.gameObject.SetActive(false));
        //ImageのColorは真っ黒に設定
    }
    public void Fade(bool type, string scene)//呼び出す関数
    {
        if (type)
        {
            this._fadeImage.DOFade(endValue: 0f, duration: 1f).OnComplete(() => _fadeImage.gameObject.SetActive(false));
            //ImageのColorは真っ黒に設定
        }
        else
        {
            _fadeImage.gameObject.SetActive(true);
            this._fadeImage.DOFade(duration: 1f, endValue: 1f).OnComplete(() => SceneManager.LoadScene(scene));
            //ImageのColorは透明に設定
        }
    }



    //public void LoadGameScene(string scene) //ゲームシーンへ移動
    //{
    //    SceneManager.LoadScene("MainGame");

    //}

    //public void LoadTitle() //タイトルへ移動
    //{
    //    SceneManager.LoadScene("TitleScene");
    //}



    public void GameEnd()   //ゲーム終了
    {
        _audioSource.PlayOneShot(_exitSE);  //終了時のSE鳴らしてから
        Invoke(nameof(GameQuit), 1.0f);   //1秒後にゲームを終了する
    }

    void GameQuit()
    {
        Application.Quit();
    }

}