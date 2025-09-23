using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public float spd = 2f; // 이동 속도
    public float dirInterval = 2f; // 방향 전환 간격

    private int dir = 1; // 현재 이동 방향: 1 또는 -1
    private float timer = 0f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        Vector2 newPos = rb.position + Vector2.right * dir * spd * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }

    // 방향 전환 타이머
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= dirInterval)
        {
            timer = 0f;
            RandomDir();
        }
    }

    // 벽 충돌 시 방향 전환
    void OnCollisionEnter2D(Collision2D collision) { ReverseDir(); }

    // 랜덤 방향 전환
    void RandomDir()
    {
        dir = Random.value > 0.5f ? 1 : -1;
        UpdateSprite();
    }

    // 강제 방향 전환
    void ReverseDir()
    {
        dir *= -1;
        UpdateSprite();
    }

    // 이동 방향 전환 시 고양이가 바라보는 방향 변경
    void UpdateSprite()
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * dir;
        transform.localScale = scale;
    }
}