using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject EndingScreen;
    public static GameManager GM;
    public int enemyCount;
    public int startingCount;
    public Image start1;
    public Image start2;
    public Image start3;
    public Sprite goldenStar;
    public bool GameOver;

    // Start is called before the first frame update
    void Start()
    {
        GM = this;
        enemyCount = Enemy.EnemiesAlive;
        startingCount = enemyCount;
        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            enemyCount = Enemy.EnemiesAlive;
            EndingScreen.SetActive(true);


            if (enemyCount <= 2) { 
            start1.sprite = goldenStar;
            }

            if (enemyCount <= 1)
            {
                start2.sprite = goldenStar;
            }

            if (enemyCount <= 0)
            {
                start3.sprite = goldenStar;
            }

        }
    }


    public void onClickMenuButton()
    {
        SceneManager.LoadScene(0);
    }


    public void onClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}