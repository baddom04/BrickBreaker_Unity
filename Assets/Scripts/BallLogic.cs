using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallLogic : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, 0, -speed, ForceMode.Impulse);
    }
    void Update()
    {
        if (transform.position.y < -5) SceneManager.LoadScene("Level1");

        // For safety on Mobile
        foreach (Touch touch in Input.touches)
        {
            if (touch.tapCount == 2) InitBall();
        }

        //For safety on PC
        if (Input.GetKeyDown(KeyCode.Space)) InitBall();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 heading = other.transform.position - transform.position;
            Vector3 direction = -heading / heading.magnitude;
            rb.velocity = direction * speed;
        }
    }
    private void InitBall()
    {
        transform.position = new Vector3(0, 0.25f, 0);
        rb.velocity = Vector3.zero; //Vector3.zero = new Vector3(0, 0, 0)
        rb.AddForce(0, 0, -speed, ForceMode.Impulse);
    }
}
