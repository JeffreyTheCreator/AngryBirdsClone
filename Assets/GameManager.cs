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


    private void SetStarsAmount(int stars, int levelIndex)
    {
        if (PlayerPrefs.GetInt("level" + levelIndex.ToString() + "stars", 0) < stars)
        {
            PlayerPrefs.SetInt("level" + levelIndex.ToString() + "stars", stars);
        }  
    }


    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            enemyCount = Enemy.EnemiesAlive;
            EndingScreen.SetActive(true);


            int currentLevel = SceneManager.GetActiveScene().buildIndex;

            if (enemyCount <= 2) { 
            start1.sprite = goldenStar;
                SetStarsAmount(1, currentLevel);
            }

            if (enemyCount <= 1)
            {
                start2.sprite = goldenStar;
                SetStarsAmount(2, currentLevel);
            }

            if (enemyCount <= 0)
            {
                start3.sprite = goldenStar;
                SetStarsAmount(3, currentLevel);
                PlayerPrefs.SetInt("levelbeaten", currentLevel);
            }

            Enemy.EnemiesAlive = 0;
            GameOver = false;

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