using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 5;
    public enum Control { Mouse, KeyBoard }
    public Control myControl;
    void Update()
    {
        //PC Mouse Control
        if (myControl.Equals(Control.Mouse))
        {
            Vector2 mousePos;
            mousePos.x = Input.mousePosition.x;
            mousePos.y = Camera.main.pixelHeight - Input.mousePosition.x;

            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(
                mousePos.x,
                mousePos.y,
                Camera.main.nearClipPlane
            ));

            transform.position = new Vector3(point.x * speed,
                                             transform.position.y,
                                             transform.position.z);
        }
        //PC KeyBoard Control
        else if (myControl.Equals(Control.KeyBoard))
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= Vector3.right * Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
        }
        //Mobile control
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 2f && transform.position.x > -3.5f)
            {
                transform.position -= Vector3.right * Time.deltaTime * speed;
            }
            if (touch.position.x > Screen.width / 2f && transform.position.x < 3.5f)
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
        }
    }
}
