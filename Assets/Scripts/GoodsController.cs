using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsController : MonoBehaviour
{
    public GoodsType goodsType;

    void Start() { Debug.Log($"[Goods] Spawned: {goodsType}"); }

    // 굿즈 충돌 처리
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);

        if (layerName == "Floor")
        {
            int damage = 0;
            switch (goodsType)
            {
                case GoodsType.Normal: damage = 1; break;
                case GoodsType.Scadi: damage = 2; break;
                case GoodsType.Limited: damage = 3; break;
            }

            GameManager.Instance?.ReduceMental(damage);
            Destroy(gameObject);
        }
        else if (layerName == "Pril") { Destroy(gameObject); }
    }
}