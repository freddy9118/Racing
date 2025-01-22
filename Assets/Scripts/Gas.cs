using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Gas : MonoBehaviour
{
    private float speed;
    void Start()
    {
        speed = 5f;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position -= Vector3.up * (speed * Time.deltaTime);
    }
}
