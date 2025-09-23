using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // 이동 속도

    // 릿지드바디 설정
    public Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // 혹시 몰라서 추가
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }


    // 이동 로직
    void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        Vector2 newPos = rb.position + Vector2.right * moveX * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);

        // 좌우 반전
        if (moveX != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Sign(moveX) * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }
}