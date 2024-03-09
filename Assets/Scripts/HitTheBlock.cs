using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTheBlock : MonoBehaviour
{
    public int health;
    private Color[] colors = {
                              new Color(255, 0, 0, 255),
                              Color.cyan,
                              Color.magenta,
                              new Color(0, 255, 0, 255),
                              new Color(0, 0, 255, 255)
                              };

    void Start()
    {
        GetComponent<Renderer>().material.color = colors[health - 1];
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Ball"){
            health--;
            if(health == 0) Destroy(gameObject);
            else GetComponent<Renderer>().material.color = colors[health - 1];
        }
    }
}
