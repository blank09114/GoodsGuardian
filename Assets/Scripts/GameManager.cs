using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static float finalTime = 0f;

    public Text timerText;
    public Image[] mentals;

    public int mental = 5;
    public int maxMental = 5;

    private float time = 0f;
    private float updateTimer = 0f;
    private float updateInterval = 0.1f;

    void Awake() { if (Instance == null) { Instance = this; } }

    void Update()
    {
        // 타이머 갱신
        time += Time.deltaTime;
        updateTimer += Time.deltaTime;

        if (updateTimer >= updateInterval)
        {
            updateTimer = 0f;
            timerText.text = $"Time: {Mathf.Floor(time * 10f) / 10f:0.0}s";
        }
    }

    // 멘탈 감소 & 게임 오버 처리
    public void ReduceMental(int amount)
    {
        mental -= amount;
        mental = Mathf.Clamp(mental, 0, maxMental);

        UpdateMentalUI();

        if (mental <= 0) { GameOver(); }
    }


    // 멘탈 UI 업데이트
    void UpdateMentalUI()
    { for (int i = 0; i < mentals.Length; i++) { mentals[i].enabled = (i < mental); } }

    // 게임 오버
    void GameOver()
    {
        finalTime = time;
        Debug.Log("[GameManager] Game Over!");
        SceneManager.LoadScene("ResultScene");
    }
}
