using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private SpriteRenderer sp;
    public float offsetSpeed = 0.5f;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Y축 방향으로 텍스처 오프셋 계산
        float offsetVal = offsetSpeed * Time.deltaTime;
        sp.material.SetTextureOffset("_MainTex", sp.material.mainTextureOffset + new Vector2(0f, offsetVal));
    }
}
