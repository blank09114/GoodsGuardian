using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // 홈 씬 호출
    public void LoadHome() { SceneManager.LoadScene("MainScene"); }

    // 플레이 씬 호출
    public void PlayGame() { SceneManager.LoadScene("PlayScene"); }

    // 게임 오버 씬 호출
    public void GameOver() { SceneManager.LoadScene("ResultScene"); }

    // 게임 종료
    public void QuitGame() { Application.Quit(); }
}