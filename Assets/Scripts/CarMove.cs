using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CarMove : MonoBehaviour
{
    public Slider gasSlider;

    public GameManager gm;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && gm.isGameOver == false)
        {
            if (transform.position.x < 1.2f)
            {
                transform.position = new Vector3(transform.position.x+1.2f, transform.position.y, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.A) && gm.isGameOver == false)
        {
            if (transform.position.x > -1.2f)
            {
                transform.position = new Vector3(transform.position.x-1.2f, transform.position.y, 0);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gas"))
        {
            gasSlider.value += 30f;
        }
    }
}
