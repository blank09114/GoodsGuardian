using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DropManager : MonoBehaviour
{
    public GameObject[] goodsPrefabs; // 굿즈 프리팹 지정

    // 생성 위치
    public float minX = -7.9f;
    public float maxX = 3.1f;
    public float dropY = 3.2f;

    // 생성 간격
    public float interval = 2f;
    public float minInterval = 1f;

    // 중력 강도
    private float grav = 0.5f;
    public float maxGrav = 1.5f;

    // 난이도 제어
    private float gravTimer = 0f;
    public float gravBoostInterval = 20f;
    public float gravInc = 0.2f;
    public float dropSpdInc = 0.2f;

    private float timer = 0f;

    void Update()
    {
        // 드롭 타이머
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;
            RandomDrop();
        }

        // 난이도 상승 제어
        gravTimer += Time.deltaTime;
        if (gravTimer >= gravBoostInterval)
        {
            gravTimer = 0f;

            // 중력 증가
            if (grav < maxGrav)grav = Mathf.Min(grav + gravInc, maxGrav);

            // 생성 간격 감소
            if (interval > minInterval)interval = Mathf.Max(interval - dropSpdInc, minInterval);
        }
    }

    void RandomDrop()
    {
        float x = Random.Range(minX, maxX);
        Vector3 pos = new Vector3(x, dropY, 0);

        List<GameObject> availablePrefabs = new List<GameObject>();

        // 굿즈 종류 추가
        availablePrefabs.Add(goodsPrefabs[0]);
        if (Time.time >= 20f)availablePrefabs.Add(goodsPrefabs[1]);
        if (Time.time >= 40f)availablePrefabs.Add(goodsPrefabs[2]);

        // 무작위 선택
        int index = Random.Range(0, availablePrefabs.Count);
        GameObject prefab = availablePrefabs[index];

        GameObject instance = Instantiate(prefab, pos, Quaternion.identity);

        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        if (rb != null) rb.gravityScale = grav;
    }

}
