using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public Text endText;
    public float restartTimer = 5;
    public GameObject ball;
    public Transform brickParent;
    private void Start() {
        endText.gameObject.SetActive(false);
    }
    void Update()
    {
        if(brickParent.childCount == 0){
            Destroy(ball.gameObject);
            endText.gameObject.SetActive(true);
            if(restartTimer > 0){
                restartTimer -= Time.deltaTime;
                endText.text = "Congratulations!\n You completed the game!\n Restart in: " + Mathf.Round(restartTimer) +"s";
            }
            else if(restartTimer < 0){
                endText.gameObject.SetActive(false);
                SceneManager.LoadScene("Level1");
            }
        }
    }
}
