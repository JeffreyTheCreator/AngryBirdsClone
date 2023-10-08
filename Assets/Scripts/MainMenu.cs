using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject lockButton;
    public Image[] level1Star;
    public Image[] level2Star;

    public Sprite goldenStar;

    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetInt("levelunlocked", 0) == 1)
        {
            lockButton.SetActive(false);
        }

        int i = 0;
        while (PlayerPrefs.GetInt("level1stars", 0) != i)
        {
            level1Star[i].sprite = goldenStar;
            i++;
        }

        i = 0;
        while (PlayerPrefs.GetInt("level2stars", 0) != i)
        {
            level1Star[i].sprite = goldenStar;
            i++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OnClickLevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickLevelTwo()
    {
        SceneManager.LoadScene(2);
    }

}