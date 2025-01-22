using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMove : MonoBehaviour
{
    public Slider gasSlider;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (transform.position.x < 1.2f)
            {
                transform.position = new Vector3(transform.position.x+1.2f, transform.position.y, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (transform.position.x > -1.2f)
            {
                transform.position = new Vector3(transform.position.x-1.2f, transform.position.y, 0);
            }
        }
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Gas"))
        {
            gasSlider.value += 30f;
        }
    }
}
