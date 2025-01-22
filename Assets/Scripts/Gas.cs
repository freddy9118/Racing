using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gas : MonoBehaviour
{
    private float speed;
    void Start()
    {
        speed = 5f;
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.up * (speed * Time.deltaTime);
    }
}
