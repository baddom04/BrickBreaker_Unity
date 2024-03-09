using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject brickPrefab;
    public Transform brickParent;
    public Text levelText;
    public Text brickText;

    void Start()
    {
        Init_Map(SceneManager.GetActiveScene().name);
    }
    void Update()
    {
        if (brickParent.childCount == 0)
        {
            if (SceneManager.GetActiveScene().name == "Level1") SceneManager.LoadScene("Level2");
            else if (SceneManager.GetActiveScene().name == "Level2") SceneManager.LoadScene("Level3");
        }

        levelText.text = SceneManager.GetActiveScene().name;
        brickText.text = brickParent.childCount + " bricks left";

        //*For testing purposes
        if(Input.GetKeyDown(KeyCode.Delete)){
            for (int i = 0; i < brickParent.childCount; i++)
            {
                Destroy(brickParent.GetChild(i).gameObject);
            }
        }
    }

    private void Init_Map(string levelName)
    {
        switch (levelName)
        {
            case "Level1":
                map1();
                break;
            case "Level2":
                map2();
                break;
            case "Level3":
                map3();
                break;
            default:
                Debug.LogException(new System.Exception("Invalid scene name!"), this);
                break;
        }
    }
    private void map1()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (j % 2 == 0 && i % 2 == 0)
                {
                    brickPrefab.GetComponent<HitTheBlock>().health = i + 1;
                    Instantiate(brickPrefab, new Vector3(j - 4, brickPrefab.transform.localScale.y / 2f, 4.25f - (i * 0.5f)), Quaternion.identity, brickParent);
                }
            }
        }
    }
    private void map2()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (j % 2 == 1 && i % 2 == 1)
                {
                    brickPrefab.GetComponent<HitTheBlock>().health = 4;
                    Instantiate(brickPrefab, new Vector3(j - 4, brickPrefab.transform.localScale.y / 2f, 4.25f - (i * 0.5f)), Quaternion.identity, brickParent);
                }
            }
        }
    }
    private void map3()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                brickPrefab.GetComponent<HitTheBlock>().health = 2;
                Instantiate(brickPrefab, new Vector3(j - 4, brickPrefab.transform.localScale.y / 2f, 4.25f - (i * 0.5f)), Quaternion.identity, brickParent);
            }
        }
    }


}
